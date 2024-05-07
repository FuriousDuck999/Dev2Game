using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class TextFadeInAndSwitch : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public float fadeInDuration = 1.5f;
    public float delayBeforeSwitch = 3f;
    public AudioSource src;

    void Start()
    {
        // Start the fading in process
        StartCoroutine(FadeInText());
    }

    IEnumerator FadeInText()
    {
        // Set the alpha to 0 to start with
        Color originalColor = textMeshPro.color;
        textMeshPro.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        src.Play();

        // Gradually increase the alpha value to 1 over fadeInDuration seconds
        float timer = 0f;
        while (timer < fadeInDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeInDuration);
            textMeshPro.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            timer += Time.deltaTime;
            yield return null;
        }

        // Wait for delayBeforeSwitch seconds
        yield return new WaitForSeconds(delayBeforeSwitch);

        // Load Scene 0
        SceneManager.LoadScene(0);
    }
}