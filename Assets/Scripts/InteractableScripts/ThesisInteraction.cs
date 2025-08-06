using UnityEngine;
using UnityEngine.SceneManagement;

public class ThesisInteraction : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
            SceneManager.LoadScene("Wordle");
    }
}
