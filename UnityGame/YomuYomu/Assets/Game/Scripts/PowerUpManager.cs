using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
using TMPro;

public class PowerUpManager : MonoBehaviour
{
    public enum PowerUpType { FreezeTime, KanaClean, HintFlash }

    [Header("Riferimenti")]
    public KanaGameManager gameManager;
    public Button powerUpButton;
    public RectTransform canvasRect;
    public TextMeshProUGUI powerUpText;

    [Header("Timer")]
    public float spawnInterval = 60f;
    public float moveDuration = 1f;

    private PowerUpType currentPowerUp;
    private Coroutine spawnCoroutine;

    void Start()
    {
        powerUpButton.gameObject.SetActive(false);
        powerUpButton.onClick.AddListener(OnPowerUpClicked);
        spawnCoroutine = StartCoroutine(SpawnPowerUpRoutine());
    }

    IEnumerator SpawnPowerUpRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnPowerUp();
        }
    }

    void SpawnPowerUp()
    {
        currentPowerUp = (PowerUpType)Random.Range(0, 3);

        ColorBlock cb = powerUpButton.colors;
        switch (currentPowerUp)
        {
            case PowerUpType.FreezeTime:
                powerUpText.text = "Freeze";
                cb.normalColor = Color.cyan;
                break;
            case PowerUpType.KanaClean:
                powerUpText.text = "Clean";
                cb.normalColor = Color.red;
                break;
            case PowerUpType.HintFlash:
                powerUpText.text = "Hint";
                cb.normalColor = Color.green;
                break;
        }
        powerUpButton.colors = cb;

        RectTransform buttonRect = powerUpButton.GetComponent<RectTransform>();

        // Posizione iniziale (destra centro)
        float halfW = canvasRect.rect.width / 2f;
        float halfH = canvasRect.rect.height / 2f;
        Vector2 startPos = new Vector2(halfW + 100f, 0f); // fuori dallo schermo a destra
        Vector2 endPos = new Vector2(-halfW - 100f, 0f);  // fuori dallo schermo a sinistra

        buttonRect.anchoredPosition = startPos;
        powerUpButton.gameObject.SetActive(true);

        // Movimento da destra a sinistra
        buttonRect.DOAnchorPos(endPos, moveDuration)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                HidePowerUp();
            });
    }

    void OnPowerUpClicked()
    {
        HidePowerUp();

        switch (currentPowerUp)
        {
            case PowerUpType.FreezeTime:
                gameManager.ActivateFreezeTime();
                break;
            case PowerUpType.KanaClean:
                //gameManager.ApplyKanaClean();
                gameManager.ActivateFreezeTime();
                break;
            case PowerUpType.HintFlash:
                gameManager.ActivateHintFlash();
                break;
        }
    }

    void HidePowerUp()
    {
        powerUpButton.transform.DOKill();
        powerUpButton.gameObject.SetActive(false);
    }
}
