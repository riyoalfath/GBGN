using UnityEngine;
using UnityEngine.UI;

public class BGMController : MonoBehaviour
{
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private Toggle bgmToggle;
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        // Inisialisasi volume slider
        volumeSlider.minValue = 0f;
        volumeSlider.maxValue = 1f;
        volumeSlider.value = bgmSource.volume;

        // Event listener
        bgmToggle.isOn = bgmSource.isPlaying;
        bgmToggle.onValueChanged.AddListener(OnToggleMusic);
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    private void OnToggleMusic(bool isOn)
    {
        if (isOn)
        {
            if (!bgmSource.isPlaying)
            {
                bgmSource.UnPause();
                if (bgmSource.time == 0) bgmSource.Play();
            }
        }
        else
        {
            bgmSource.Pause();
        }
    }

    private void OnVolumeChanged(float value)
    {
        bgmSource.volume = value;
    }
}
