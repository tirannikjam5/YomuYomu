using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class KanaGameManager : MonoBehaviour
{
    [Header("Riferimenti UI")]
    public RectTransform fallingWord;
    public TextMeshProUGUI wordDisplay;
    public Button[] kanaButtons; // 4 bottoni UI
    public TextMeshProUGUI[] kanaTexts;
    public TextMeshProUGUI traduzioneText;


    [Header("Dati")]
    public List<WordData> wordPool;
    public KanaDatabase kanaDatabase;

    private WordData currentWord;
    private int currentKanaIndex = 0;
    private List<string> currentKanaIDs = new List<string>();

    private Vector3 startPosition;
    private Coroutine fallingCoroutine;

    private float loseThresholdY;
    private bool gameOver = false;
    

    [Header("Difficoltà")]
    public float startFallSpeed = 50f;
    public float maxFallSpeed = 200f;
    public float increasePerWord = 10f;
    public float increasePerError = 5f;

    public float currentFallSpeed;

    [Header("Punteggio")]
    public TextMeshProUGUI scoreText;
    public int pointsPerWord = 5;

    private int currentScore = 0;
    private int bestScore = 0;
    private Tween scoreTween;

    [Header("Audio")]
    public AudioClip successAudio;  

    private List<WordData> shuffledWordPool = new List<WordData>();


    void Start()
    {
        startPosition = fallingWord.localPosition;
        LoadNextWord();

        loseThresholdY = -Screen.height / 2f - Screen.height * 0.05f;
        currentFallSpeed = startFallSpeed;

        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = $"best: {bestScore}\ncurrent: {currentScore}";
    }

    void AddScoreSmooth(int amount)
    {
        int startValue = currentScore;
        int endValue = currentScore + amount;

        if (scoreTween != null && scoreTween.IsPlaying())
            scoreTween.Kill();

        scoreTween = DOTween.To(
            () => startValue,
            x =>
            {
                currentScore = x;
                UpdateScoreUI();
            },
            endValue,
            0.5f
        ).OnComplete(() =>
        {
            // se supera il best
            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                PlayerPrefs.SetInt("BestScore", bestScore);
                PlayerPrefs.Save();

                scoreText.transform.DOPunchScale(Vector3.one * 0.2f, 0.3f, 8);
            }
        });
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            kanaButtons[3].onClick.Invoke();

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            kanaButtons[2].onClick.Invoke();

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            kanaButtons[1].onClick.Invoke();

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            kanaButtons[0].onClick.Invoke();

         if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    void LoadNextWord()
    {
       if (shuffledWordPool.Count == 0)
        {
            // Ricrea una lista mescolata
            shuffledWordPool = new List<WordData>(wordPool);
            for (int i = 0; i < shuffledWordPool.Count; i++)
            {
                int rnd = Random.Range(i, shuffledWordPool.Count);
                var temp = shuffledWordPool[i];
                shuffledWordPool[i] = shuffledWordPool[rnd];
                shuffledWordPool[rnd] = temp;
            }
        }

        // Prendi la prossima parola da quella mescolata
        currentWord = shuffledWordPool[0];
        shuffledWordPool.RemoveAt(0);
        
        currentKanaIDs = currentWord.GetRomajiIDs(kanaDatabase);
        currentKanaIndex = 0;

        UpdateWordVisual();
        GenerateKanaChoices();

        if (fallingCoroutine != null) StopCoroutine(fallingCoroutine);
        fallingCoroutine = StartCoroutine(FallRoutine());

        Invoke(nameof(PlayWordAudio), 0.5f);

        if (traduzioneText != null)
            traduzioneText.text = "";
    }

    void UpdateWordVisual()
    {
        string display = "";
        for (int i = 0; i < currentKanaIDs.Count; i++)
        {
            var kana = kanaDatabase.GetKana(currentKanaIDs[i]);
            if (i < currentKanaIndex)
                display += $"<color=green>{kana.GetKanaSymbol(currentWord.kanaType)}</color>";
            else
                display += $"<color=red>{kana.GetKanaSymbol(currentWord.kanaType)}</color>";
        }
        wordDisplay.text = display;
    }

    void GenerateKanaChoices()
    {
        string correctID = currentKanaIDs[currentKanaIndex];
        var correctKana = kanaDatabase.GetKana(correctID);

        List<KanaData> choices = kanaDatabase.GetRandomKana(currentWord.kanaType, 3, exclude: correctID);
        int correctIndex = Random.Range(0, 4);
        choices.Insert(correctIndex, correctKana);

        for (int i = 0; i < 4; i++)
        {
            kanaTexts[i].text = choices[i].GetKanaSymbol(currentWord.kanaType);

            int localIndex = i; // copia locale per evitare il problema
            KanaData kanaRef = choices[localIndex];
            kanaButtons[i].onClick.RemoveAllListeners();
            kanaButtons[i].onClick.AddListener(() =>
            {
                OnKanaClicked(kanaRef, kanaButtons[localIndex].transform);
            });
        }
    }

    void OnKanaClicked(KanaData selectedKana, Transform buttonTransform)
    {

        if (gameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        } 
            

        buttonTransform.DOPunchScale(Vector3.one * 0.2f, 0.2f, 10);

        if (selectedKana.audioClip != null)
            AudioSource.PlayClipAtPoint(selectedKana.audioClip, Camera.main.transform.position);

        if (selectedKana.romaji == currentKanaIDs[currentKanaIndex])
        {
            currentKanaIndex++;
            wordDisplay.transform.DOPunchScale(Vector3.one * 0.2f, 0.2f, 10);

            UpdateWordVisual(); // ✅ aggiorna SEMPRE la visuale prima del controllo

            if (currentKanaIndex >= currentKanaIDs.Count) //giusta
            {
                currentFallSpeed = Mathf.Min(currentFallSpeed + increasePerWord, maxFallSpeed);
                if (currentWord.audioClip != null)
                {
                     AudioSource.PlayClipAtPoint(successAudio, Camera.main.transform.position);
                     Invoke(nameof(PlayWordAudio), 0.5f);
                }


                if (traduzioneText != null)
                {
                    traduzioneText.text = currentWord.traduzioneItaliana;
                    traduzioneText.transform.DOPunchScale(Vector3.one * 0.2f, 0.2f, 10);

                    wordDisplay.text= currentWord.traduzioneItaliana;
                }

                AddScoreSmooth(pointsPerWord);
                Invoke(nameof(LoadNextWord), 1.5f);
                return;
            }

            GenerateKanaChoices();
        }
        else
        {
            // ERRORE → aumenta difficoltà
            currentFallSpeed = Mathf.Min(currentFallSpeed + increasePerError, maxFallSpeed);
            wordDisplay.transform.DOPunchScale(Vector3.one * 0.3f, 0.3f, 10); // effetto errore
        }
    }


    void PlayWordAudio()
    {
        AudioSource.PlayClipAtPoint(currentWord.audioClip, Camera.main.transform.position);
    }


    IEnumerator FallRoutine()
    {
        fallingWord.localPosition = startPosition;

        while (true)
        {
            fallingWord.localPosition += Vector3.down * Time.deltaTime * currentFallSpeed;

            if (!gameOver && fallingWord.localPosition.y < loseThresholdY)
            {
                gameOver = true;
                OnLose();
                yield break;
            }

            yield return null;
        }
    }

    void OnLose()
    {
        Debug.Log("💀 Hai perso!");

        // Ferma la parola al centro dello schermo
        if (fallingCoroutine != null) StopCoroutine(fallingCoroutine);
        fallingWord.localPosition = Vector3.zero;

        Time.timeScale = 0;
        wordDisplay.text = "<color=red> Game Over </color>";
        
    }

}
