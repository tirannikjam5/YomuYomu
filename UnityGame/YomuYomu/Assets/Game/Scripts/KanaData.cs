using UnityEngine;

public enum KanaType
{
    Hiragana,
    Katakana
}

[CreateAssetMenu(fileName = "NewKana", menuName = "YomuYomu/Kana")]
public class KanaData : ScriptableObject
{
    [Header("Visuale e pronuncia")]
    public string hiragana;         // Es. "ね"
    public string katakana;
    public string romaji;       // Es. "ne"
    public AudioClip audioClip; // Audio del suono

    public string GetKanaSymbol(KanaType type)
    {
        return type == KanaType.Hiragana ? hiragana : katakana;
    }
}
