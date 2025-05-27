using UnityEngine;
using System.Collections.Generic;
using System.Linq;


[CreateAssetMenu(fileName = "NewWord", menuName = "YomuYomu/Word")]
public class WordData : ScriptableObject
{
    [Header("Contenuto della parola")]
    public string wordKana;                    // Es. ねこ o ネコ
    private List<string> kanaRomajiIDs;        // Es. ["ne", "ko"]
    public string traduzioneItaliana;         // Es. "gatto"
    public AudioClip audioClip;               // Audio intero della parola
    public string romaji;

    [Header("Tipo di scrittura")]
    public KanaType kanaType;                 // Hiragana o Katakana
    


    /// <summary>
    /// Ritorna la lista dei romaji in base al kana contenuto nella parola, usando il KanaDatabase
    /// </summary>
    public List<string> GetRomajiIDs(KanaDatabase database)
    {
        var result = new List<string>();
        var kanaList = database.allKana;
        int i = 0;

        var validKana = new HashSet<string>(
            kanaList.SelectMany(k => new[] { k.hiragana, k.katakana }).Where(k => !string.IsNullOrEmpty(k))
        );

        while (i < wordKana.Length)
        {
            if (i + 1 < wordKana.Length)
            {
                string twoChar = wordKana.Substring(i, 2);
                if (validKana.Contains(twoChar))
                {
                    var data = kanaList.FirstOrDefault(k => k.hiragana == twoChar || k.katakana == twoChar);
                    if (data != null) result.Add(data.romaji);
                    i += 2;
                    continue;
                }
            }

            string oneChar = wordKana.Substring(i, 1);
            var single = kanaList.FirstOrDefault(k => k.hiragana == oneChar || k.katakana == oneChar);
            if (single != null) result.Add(single.romaji);
            else Debug.LogWarning($"❌ Kana sconosciuto: {oneChar}");
            i += 1;
        }

        return result;
    }
}
