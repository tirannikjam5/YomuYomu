using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;

public class WordDataGenerator : EditorWindow
{
    [MenuItem("YomuYomu/Genera WordData (parole)")]
    public static void ShowWindow()
    {
        GetWindow(typeof(WordDataGenerator));
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Genera le parole base"))
        {
            GenerateWordData();
        }
    }

    static void GenerateWordData()
    {
        string savePath = "Assets/Game/Scriptable/WordsNew";
        if (!Directory.Exists(savePath))
            Directory.CreateDirectory(savePath);

        // Carica tutti gli audio dalla cartella parole
        var audioClips = AssetDatabase
            .FindAssets("t:AudioClip", new[] { "Assets/Game/Audio/WordsNew" })
            .Select(guid => AssetDatabase.GUIDToAssetPath(guid))
            .Select(path => AssetDatabase.LoadAssetAtPath<AudioClip>(path))
            .ToList();

        // Cerca un audio chiamato "w-romaji"
        AudioClip FindClip(string romaji)
        {
            return audioClips.FirstOrDefault(c =>
                c.name == $"w_{romaji}" || c.name == $"w-{romaji}" || c.name.EndsWith(romaji)
            );
        }

        // Lista di parole da generare (hiragana/katakana, romaji, traduzione, tipo)
        var words = new (string kana, string romaji, string traduzione, KanaType tipo)[]
        {
            ("ごみ", "gomi", "spazzatura", KanaType.Hiragana),
            ("ハンカチ", "hankachi", "fazzoletto", KanaType.Katakana),
            ("ヒーター", "hiitaa", "stufa", KanaType.Katakana),
            ("アイスクリーム", "icecream", "gelato", KanaType.Katakana),
            ("ガールズ", "igirlsu", "ragazze", KanaType.Katakana),
            ("ジャケット", "jacket", "giacca", KanaType.Katakana),
            ("きのう", "kinou", "ieri", KanaType.Hiragana),
            ("こんげつ", "kongetsu", "questo mese", KanaType.Hiragana),
            ("こんしゅう", "konshuu", "questa settimana", KanaType.Hiragana),
            ("ことし", "kotoshi", "quest'anno", KanaType.Hiragana),
            ("きょねん", "kyonen", "l’anno scorso", KanaType.Hiragana),
            ("きょう", "kyou", "oggi", KanaType.Hiragana),
            ("メール", "mail", "mail", KanaType.Katakana),
            ("ママ", "mama", "mamma", KanaType.Katakana),
            ("ナイフ", "naifu", "coltello", KanaType.Katakana),
            ("オフィスワーク", "office_waaku", "lavoro d’ufficio", KanaType.Katakana),
            ("オーケー", "ok", "va bene", KanaType.Katakana),
            ("おととい", "ototoi", "l’altro ieri", KanaType.Hiragana),
            ("パン", "pan", "pane", KanaType.Katakana),
            ("パンケーキ", "pankeeki", "pancake", KanaType.Katakana),
            ("パーティー", "party", "festa", KanaType.Katakana),
            ("ペン", "pen", "penna", KanaType.Katakana),
            ("ピアス", "piasu", "orecchino", KanaType.Katakana),
            ("ピザ", "piza", "pizza", KanaType.Katakana),
            ("プロジェクト", "project", "progetto", KanaType.Katakana),
            ("らいげつ", "raigetsu", "mese prossimo", KanaType.Hiragana),
            ("らいねん", "rainen", "anno prossimo", KanaType.Hiragana),
            ("らいしゅう", "raishuu", "settimana prossima", KanaType.Hiragana),
            ("サンドイッチ", "sandwich", "panino", KanaType.Katakana),
            ("サラダ", "sarada", "insalata", KanaType.Katakana),
            ("セーター", "seetaa", "maglione", KanaType.Katakana),
            ("せんげつ", "sengetsu", "mese scorso", KanaType.Hiragana),
            ("せんしゅう", "senshuu", "settimana scorsa", KanaType.Hiragana),
            ("ソファ", "sofa", "divano", KanaType.Katakana),
            ("スプーン", "spoon", "cucchiaio", KanaType.Katakana),
            ("スカート", "sukaato", "gonna", KanaType.Katakana),
            ("すてーき", "suteeki", "bistecca", KanaType.Hiragana),
            ("スーパー", "suupaa", "supermercato", KanaType.Katakana),
            ("テーブル", "table", "tavolo", KanaType.Katakana),
            ("タクシー", "takushii", "taxi", KanaType.Katakana),
            ("つあー", "tsuaa", "tour", KanaType.Hiragana),
            ("バイオリン", "violin", "violino", KanaType.Katakana),
            ("を", "wo", "particella 'o'", KanaType.Hiragana),
            ("ズボン", "zubon", "pantaloni", KanaType.Katakana),
        };


        foreach (var (kana, romaji, traduzione, tipo) in words)
        {
            WordData word = ScriptableObject.CreateInstance<WordData>();
            word.wordKana = kana;
            word.romaji = romaji;
            word.traduzioneItaliana = traduzione;
            word.kanaType = tipo;

            var clip = FindClip(romaji.Replace("_", ""));
            if (clip != null)
                word.audioClip = clip;
            else
                Debug.LogWarning($"❌ Audio non trovato per {romaji}");

            string assetPath = $"{savePath}/{romaji}.asset";
            AssetDatabase.CreateAsset(word, assetPath);
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("✅ WordData generati con successo!");
    }
}
