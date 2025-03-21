using UnityEngine;
using TMPro; // Mengimpor TextMeshPro namespace

public class LoadingText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI loadingText; // TextMeshProUGUI digunakan untuk TextMeshPro
    private int dotCount = 0;
    private float timer = 0f;
    public float dotInterval = 0.5f; // Waktu dalam detik untuk menambah titik

    void Start()
    {
        // Pastikan loadingText terhubung
        if (loadingText == null)
        {
            Debug.LogError("loadingText belum di-assign di Inspector.");
        }
    }

    void Update()
    {
        if (loadingText != null)
        {
            timer += Time.deltaTime;

            if (timer >= dotInterval)
            {
                timer = 0f;
                dotCount = (dotCount + 1) % 4; // Batas titik sampai 3, lalu ulangi
                loadingText.text = "Loading" + new string('.', dotCount);
            }
        }
    }
}

