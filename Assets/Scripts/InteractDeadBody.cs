using UnityEngine;
using System.Collections;

public class InteractDeadBody : MonoBehaviour, Interactable
{
    [SerializeField] private Dialog dialog;
    [SerializeField] private AudioClip interactAudio; // Assign the audio clip in the inspector
    private AudioSource audioSource;

    private void Start()
    {
        // Ensure there's an AudioSource component attached to the object
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void Interact()
    {
        // Start the coroutine to play audio and then show the dialog
        StartCoroutine(PlayAudioAndShowDialog());
    }

    private IEnumerator PlayAudioAndShowDialog()
    {
        if (interactAudio != null)
        {
            // Play the audio
            audioSource.PlayOneShot(interactAudio);

            // Wait for the audio to finish
            yield return new WaitForSeconds(interactAudio.length);
        }

        // Show the dialog after the audio finishes
        yield return StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
    }
}
