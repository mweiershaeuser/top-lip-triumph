using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TutorialTrigger : MonoBehaviour
{
    public GameObject tutorialBubble;
    public List<GameObject> otherGameObjects;
    public float displayTime = 2.0f; // Time for the text to stay on screen
    public float fadeDuration = 0.5f; // Duration of the fade effect

    private CanvasGroup bubbleCanvasGroup;

    private void Start()
    {
        bubbleCanvasGroup = tutorialBubble.GetComponent<CanvasGroup>();
        if (bubbleCanvasGroup == null)
        {
            bubbleCanvasGroup = tutorialBubble.AddComponent<CanvasGroup>();
        }
        bubbleCanvasGroup.alpha = 0; // Start with an invisible text
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject gameObj in otherGameObjects) {
                gameObj.SetActive(false);
            }
            StopAllCoroutines(); // Stop any ongoing fade out coroutine
            StartCoroutine(FadeCanvasGroup(bubbleCanvasGroup, bubbleCanvasGroup.alpha, 1, fadeDuration)); // Fade in
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DelayedFadeOut());
        }
    }

    IEnumerator DelayedFadeOut()
    {
        yield return new WaitForSeconds(displayTime);
        StartCoroutine(FadeCanvasGroup(bubbleCanvasGroup, bubbleCanvasGroup.alpha, 0, fadeDuration)); // Fade out
    }

    IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float duration)
    {
        float counter = 0f;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            cg.alpha = Mathf.Lerp(start, end, counter / duration);
            yield return null;
        }
    }
}
