using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public string loadingSceneName;
    public string destinationSceneName;
    public float loadingTime = 3f;

    private void Start()
    {
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        SceneManager.LoadScene(loadingSceneName);
        yield return new WaitForSeconds(loadingTime);
        SceneManager.LoadScene(destinationSceneName);
    }
}
