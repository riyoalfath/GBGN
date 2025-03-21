using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    public void BackButton () {
        SceneManager.LoadScene(0);
    }
}
