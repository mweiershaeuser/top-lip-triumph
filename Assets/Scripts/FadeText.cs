using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FadeTextOnKeyPress : MonoBehaviour
{
    public List<Text> tutorialTexts;
    public GameObject additionalCanvas; // The additional canvas to show
    public float fadeDuration = 1.0f;
    public float canvasDisplayTime = 2.0f; // Time to display the additional canvas

    private bool allTextsFaded = false;
    private Dictionary<Text, bool> textFullyVisible = new Dictionary<Text, bool>(); // Track if text is fully visible
    private HashSet<Text> fadedTexts = new HashSet<Text>(); // Track faded texts

    void Start()
    {
        foreach (Text text in tutorialTexts)
        {
            textFullyVisible[text] = false; 
            StartCoroutine(FadeTextFromZeroAlpha(text)); // Fade in each text at the start
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) ||
            Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            if (!allTextsFaded)
            {
                foreach (Text text in tutorialTexts)
                {
                    if (!fadedTexts.Contains(text) && textFullyVisible[text]) // Check if the text has already been faded
                    {
                        StartCoroutine(FadeTextToZeroAlpha(text));
                        fadedTexts.Add(text); // Add to faded texts
                    }
                }
                allTextsFaded = AllTextsFaded();
            }
        }
    }

    IEnumerator FadeTextFromZeroAlpha(Text text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / fadeDuration));
            yield return null;
        }
        textFullyVisible[text] = true; 
    }

    IEnumerator FadeTextToZeroAlpha(Text text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, 
                                   text.color.g, 
                                   text.color.b, 
                                   text.color.a - (Time.deltaTime / fadeDuration));
            yield return null;
        }
        text.gameObject.SetActive(false);
        fadedTexts.Add(text);

        // Check if all texts are faded
        if (AllTextsFaded())
        {
            StartCoroutine(ShowAndHideCanvas());
        }
    }

    IEnumerator ShowAndHideCanvas()
    {
        // Fade in the canvas
        additionalCanvas.SetActive(true);
        CanvasGroup canvasGroup = additionalCanvas.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = additionalCanvas.AddComponent<CanvasGroup>();
        }

        while (canvasGroup.alpha < 1.0f)
        {
            canvasGroup.alpha += Time.deltaTime / fadeDuration;
            yield return null;
        }

        // Wait for a certain time
        yield return new WaitForSeconds(canvasDisplayTime);

        // Fade out the canvas
        while (canvasGroup.alpha > 0.0f)
        {
            canvasGroup.alpha -= Time.deltaTime / fadeDuration;
            yield return null;
        }

        additionalCanvas.SetActive(false);
    }
    bool AllTextsFaded()
    {
        // Modify this function to check the fadedTexts set
        return fadedTexts.Count == tutorialTexts.Count;
    }
}
