using System.Collections.Generic;
using UnityEngine;

public class BackgroundColor : MonoBehaviour
{
    [Header("Colore dello sfondo")]
    public SpriteRenderer targetRenderer;

    [Tooltip("Lista di colori da usare nel tempo")]
    public List<Color> colors = new List<Color>();

    [Tooltip("Intervallo tra cambi colore (in secondi)")]
    public float interval = 10f;

    private int currentIndex = 0;

    void Start()
    {
        if (targetRenderer == null)
            targetRenderer = GetComponent<SpriteRenderer>();

        if (colors.Count == 0 || targetRenderer == null)
        {
            Debug.LogWarning("Nessun colore o SpriteRenderer assegnato.");
            return;
        }

        targetRenderer.color = colors[0];
        InvokeRepeating(nameof(ChangeColor), interval, interval);
    }

    void ChangeColor()
    {
        currentIndex++;

        if (currentIndex >= colors.Count)
        {
            CancelInvoke(nameof(ChangeColor));
            return;
        }

        targetRenderer.color = colors[currentIndex];
    }
}
