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
            .FindAssets("t:AudioClip", new[] { "Assets/Game/Audio/Words" })
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

            ("よく", "yoku", "spesso", KanaType.Hiragana),
            ("ときどき", "tokidoki", "a volte", KanaType.Hiragana),
            ("たまに", "tama_ni", "raramente / ogni tanto", KanaType.Hiragana),
            ("いつも", "itsumo", "sempre", KanaType.Hiragana),
            ("いま", "ima", "adesso / ora", KanaType.Hiragana),
            ("もう", "mou", "già", KanaType.Hiragana),
            ("まだ", "mada", "ancora / non ancora", KanaType.Hiragana),
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
