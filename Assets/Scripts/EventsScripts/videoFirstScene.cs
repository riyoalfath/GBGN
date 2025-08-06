using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoSceneLoader : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public int nextSceneIndex;

    void Start()
    {
        // Mulai video
        videoPlayer.Play();

        // Tambahkan event listener ketika video selesai
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // Pindah ke scene berikutnya
        // SceneManager.LoadScene(nextSceneIndex);
        SceneManager.LoadScene(2);

    }
}