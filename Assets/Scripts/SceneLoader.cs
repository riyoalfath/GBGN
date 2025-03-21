using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject loaderUI;
    public Slider progressSlider;
    
    [Header("Loading Configuration")]
    public float totalLoadTime = 5f;
    public AnimationCurve progressCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadSceneDynamicProgress(sceneIndex));
    }

    private IEnumerator LoadSceneDynamicProgress(int sceneIndex)
    {
        // Prepare loading screen
        loaderUI.SetActive(true);
        progressSlider.value = 0;

        // Start async scene load
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
        asyncOperation.allowSceneActivation = false;

        float elapsedTime = 0f;
        float progress = 0f;

        while (elapsedTime < totalLoadTime)
        {
            elapsedTime += Time.deltaTime;
            float normalizedTime = elapsedTime / totalLoadTime;

            // Dynamic progress curve
            if (normalizedTime < 0.7f)
            {
                // Fast initial loading
                progress = Mathf.Lerp(0f, 0.7f, normalizedTime / 0.7f);
            }
            else
            {
                // Slow progression after 0.7
                progress = Mathf.Lerp(0.7f, 1f, (normalizedTime - 0.7f) / 0.3f);
            }

            // Apply custom curve for more natural progression
            progress = progressCurve.Evaluate(progress);

            // Update slider
            progressSlider.value = progress;

            // Allow scene activation when ready
            if (asyncOperation.progress >= 0.9f && elapsedTime >= totalLoadTime * 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
                progressSlider.value = 1f;
                break;
            }

            yield return null;
        }

        // Ensure scene activation
        asyncOperation.allowSceneActivation = true;
        progressSlider.value = 1f;
        
        // Optional: Hide loader after brief moment
        yield return new WaitForSeconds(0.2f);
        loaderUI.SetActive(false);
    }
}