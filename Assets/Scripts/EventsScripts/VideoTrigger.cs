using UnityEngine;
using UnityEngine.Video;

public class VideoTrigger : MonoBehaviour
{
    public VideoPlayer videoPlayer;         // Assign in Inspector
    public MonoBehaviour playerController;  // Assign the player movement script
    public GameObject videoCanvas;          // Assign the Canvas GameObject to show during video
    public GameObject NPCDeadbody;          // Assign the NPC Dead Body GameObject to hide after video

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player triggered video");

            // Disable player movement
            if (playerController != null)
                playerController.enabled = false;

            // Show the video canvas
            if (videoCanvas != null)
                videoCanvas.SetActive(true);

            videoPlayer.Play();
            videoPlayer.loopPointReached += OnVideoFinished;
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("Video finished. Re-enabling player movement and cleaning up.");

        // Re-enable player movement
        if (playerController != null)
            playerController.enabled = true;

        // Hide the video canvas
        if (videoCanvas != null)
            videoCanvas.SetActive(false);

        // Disable the NPC dead body
        if (NPCDeadbody != null)
            NPCDeadbody.SetActive(false);

        // Disable this trigger
        gameObject.SetActive(false);
    }
}