using UnityEngine;

public class SwitchObjectsOnEnter : MonoBehaviour
{
    [SerializeField] private GameObject currentObject; // The object to disable
    [SerializeField] private GameObject nextObject; // The object to enable
    [SerializeField] private AudioClip keyPressSoundEffect; // The SFX to play when any key is pressed
    [SerializeField] private AudioSource audioSource; // The AudioSource to play the SFX

    private void Update()
    {
        // Check if any key is pressed
        if (Input.anyKeyDown)
        {
            PlaySFX();
            SwitchObjects();
        }
    }

    private void PlaySFX()
    {
        if (audioSource != null && keyPressSoundEffect != null)
        {
            audioSource.PlayOneShot(keyPressSoundEffect);
        }
        else
        {
            Debug.LogWarning("AudioSource or Key Press Sound Effect is not assigned!");
        }
    }

    private void SwitchObjects()
    {
        Debug.Log("Key pressed. Switching objects...");

        // Disable the current object
        if (currentObject != null)
        {
            currentObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Current object is not assigned!");
        }

        // Enable the next object
        if (nextObject != null)
        {
            nextObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Next object is not assigned!");
        }
    }
}
