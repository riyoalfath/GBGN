using UnityEngine;
using UnityEngine.Video;

public class VideoEndSwitchObjects : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer; // The Video Player playing the video
    [SerializeField] private GameObject currentObject; // The object to disable after the video ends
    [SerializeField] private GameObject nextObject; // The object to enable after the video ends

    private void Start()
    {
        if (videoPlayer == null)
        {
            Debug.LogError("VideoPlayer not assigned!");
            return;
        }

        // Ensure currentObject is assigned, fallback to this GameObject
        if (currentObject == null)
        {
            currentObject = gameObject;
        }

        // Subscribe to the VideoPlayer's loopPointReached event
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("Video ended!");

        // Disable the current object
        if (currentObject != null)
        {
            currentObject.SetActive(false);
        }

        // Enable the next object
        if (nextObject != null)
        {
            nextObject.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event to prevent errors
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoEnd;
        }
    }
}