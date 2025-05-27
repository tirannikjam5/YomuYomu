using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "KanaDatabase", menuName = "YomuYomu/KanaDatabase")]
public class KanaDatabase : ScriptableObject
{
    public List<KanaData> allKana;

    /// <summary>
    /// Ritorna il KanaData associato al romaji (es. "ka" → KanaData con "か/カ")
    /// </summary>
    public KanaData GetKana(string romaji)
    {
        return allKana.FirstOrDefault(k => k.romaji == romaji);
    }

    /// <summary>
    /// Ritorna una lista di kana casuali (esclude il corretto) e usa il KanaType della Word
    /// </summary>
    public List<KanaData> GetRandomKana(KanaType targetType, int count, string exclude = "")
    {
        return allKana
            .Where(k => k.romaji != exclude) // esclude il corretto
            .OrderBy(k => Random.value)
            .Take(count)
            .ToList();
    }
}
