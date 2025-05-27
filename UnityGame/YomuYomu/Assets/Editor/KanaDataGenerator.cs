using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class KanaDataGenerator : EditorWindow
{
    [MenuItem("YomuYomu/Genera KanaData")]
    public static void ShowWindow()
    {
        GetWindow(typeof(KanaDataGenerator));
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Genera Tutti i Kana"))
        {
            GenerateKanaData();
        }
    }

    static void GenerateKanaData()
    {
        string savePath = "Assets/Game/Scriptable/Kana";
        if (!Directory.Exists(savePath))
            Directory.CreateDirectory(savePath);

        // Carica tutti gli AudioClip
        var audioClips = AssetDatabase
            .FindAssets("t:AudioClip", new[] { "Assets/Game/Audio/Kana" })
            .Select(guid => AssetDatabase.GUIDToAssetPath(guid))
            .Select(path => AssetDatabase.LoadAssetAtPath<AudioClip>(path))
            .ToList();

        // Funzione per trovare clip che finisce con "_romaji" o contiene "_romaji"
        AudioClip FindClip(string romaji)
        {
            return audioClips.FirstOrDefault(c =>
                c.name == romaji ||
                c.name.EndsWith("_" + romaji) ||
                c.name.EndsWith("-" + romaji) ||
                c.name.EndsWith("." + romaji) ||
                c.name.EndsWith(romaji) // fallback generico, attenzione a falsi positivi
            );
        }

        var kanaList = new[] {
            ("あ", "ア", "a"), ("い", "イ", "i"), ("う", "ウ", "u"), ("え", "エ", "e"), ("お", "オ", "o"),
            ("か", "カ", "ka"), ("き", "キ", "ki"), ("く", "ク", "ku"), ("け", "ケ", "ke"), ("こ", "コ", "ko"),
            ("さ", "サ", "sa"), ("し", "シ", "shi"), ("す", "ス", "su"), ("せ", "セ", "se"), ("そ", "ソ", "so"),
            ("た", "タ", "ta"), ("ち", "チ", "chi"), ("つ", "ツ", "tsu"), ("て", "テ", "te"), ("と", "ト", "to"),
            ("な", "ナ", "na"), ("に", "ニ", "ni"), ("ぬ", "ヌ", "nu"), ("ね", "ネ", "ne"), ("の", "ノ", "no"),
            ("は", "ハ", "ha"), ("ひ", "ヒ", "hi"), ("ふ", "フ", "fu"), ("へ", "ヘ", "he"), ("ほ", "ホ", "ho"),
            ("ま", "マ", "ma"), ("み", "ミ", "mi"), ("む", "ム", "mu"), ("め", "メ", "me"), ("も", "モ", "mo"),
            ("や", "ヤ", "ya"), ("ゆ", "ユ", "yu"), ("よ", "ヨ", "yo"),
            ("ら", "ラ", "ra"), ("り", "リ", "ri"), ("る", "ル", "ru"), ("れ", "レ", "re"), ("ろ", "ロ", "ro"),
            ("わ", "ワ", "wa"), ("を", "ヲ", "wo"), ("ん", "ン", "n"),
            // Dakuten
            ("が", "ガ", "ga"), ("ぎ", "ギ", "gi"), ("ぐ", "グ", "gu"), ("げ", "ゲ", "ge"), ("ご", "ゴ", "go"),
            ("ざ", "ザ", "za"), ("じ", "ジ", "ji"), ("ず", "ズ", "zu"), ("ぜ", "ゼ", "ze"), ("ぞ", "ゾ", "zo"),
            ("だ", "ダ", "da"), ("ぢ", "ヂ", "dzi"), ("づ", "ヅ", "dzu"), ("で", "デ", "de"), ("ど", "ド", "do"),
            ("ば", "バ", "ba"), ("び", "ビ", "bi"), ("ぶ", "ブ", "bu"), ("べ", "ベ", "be"), ("ぼ", "ボ", "bo"),
            // Handakuten
            ("ぱ", "パ", "pa"), ("ぴ", "ピ", "pi"), ("ぷ", "プ", "pu"), ("ぺ", "ペ", "pe"), ("ぽ", "ポ", "po"),
            // Yoon
            ("きゃ", "キャ", "kya"), ("きゅ", "キュ", "kyu"), ("きょ", "キョ", "kyo"),
            ("しゃ", "シャ", "sha"), ("しゅ", "シュ", "shu"), ("しょ", "ショ", "sho"),
            ("ちゃ", "チャ", "cha"), ("ちゅ", "チュ", "chu"), ("ちょ", "チョ", "cho"),
            ("にゃ", "ニャ", "nya"), ("にゅ", "ニュ", "nyu"), ("にょ", "ニョ", "nyo"),
            ("ひゃ", "ヒャ", "hya"), ("ひゅ", "ヒュ", "hyu"), ("ひょ", "ヒョ", "hyo"),
            ("みゃ", "ミャ", "mya"), ("みゅ", "ミュ", "myu"), ("みょ", "ミョ", "myo"),
            ("りゃ", "リャ", "rya"), ("りゅ", "リュ", "ryu"), ("りょ", "リョ", "ryo"),
            ("ぎゃ", "ギャ", "gya"), ("ぎゅ", "ギュ", "gyu"), ("ぎょ", "ギョ", "gyo"),
            ("じゃ", "ジャ", "ja"), ("じゅ", "ジュ", "ju"), ("じょ", "ジョ", "jo"),
            ("びゃ", "ビャ", "bya"), ("びゅ", "ビュ", "byu"), ("びょ", "ビョ", "byo"),
            ("ぴゃ", "ピャ", "pya"), ("ぴゅ", "ピュ", "pyu"), ("ぴょ", "ピョ", "pyo")
        };

        foreach (var (hiragana, katakana, romaji) in kanaList)
        {
            KanaData kana = ScriptableObject.CreateInstance<KanaData>();
            kana.hiragana = hiragana;
            kana.katakana = katakana;
            kana.romaji = romaji;

            var clip = FindClip(romaji);
            if (clip != null)
                kana.audioClip = clip;
            else
                Debug.LogWarning($"❌ Audio non trovato per {romaji}");

            string assetPath = $"{savePath}/{romaji}.asset";
            AssetDatabase.CreateAsset(kana, assetPath);
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("✅ KanaData generati con audio associati.");
    }
}
