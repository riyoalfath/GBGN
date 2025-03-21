using UnityEngine;
using System.Collections;

public class QuitGameButton : MonoBehaviour
{
    [SerializeField] private AudioClip quitSoundEffect; // The SFX to play before quitting
    [SerializeField] private AudioSource audioSource; // The AudioSource to play the SFX

    // This function can be linked to a button in the Unity UI
    public void QuitGame()
    {
        StartCoroutine(PlaySoundAndQuit()); // Start the coroutine to play sound and quit
    }

    private IEnumerator PlaySoundAndQuit()
    {
        // Play the quit sound effect
        if (audioSource != null && quitSoundEffect != null)
        {
            audioSource.PlayOneShot(quitSoundEffect);
        }
        else
        {
            Debug.LogWarning("AudioSource or Quit Sound Effect is not assigned!");
        }

        // Wait for the audio clip to finish before quitting
        yield return new WaitForSeconds(quitSoundEffect.length);

        Debug.Log("Quitting game...");

        // Quit the application
        Application.Quit();

        // NOTE: Application.Quit() won't work in the editor.
        // To simulate quitting in the Unity editor, use:
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
