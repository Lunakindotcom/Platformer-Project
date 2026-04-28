using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject losePanel;
    public GameObject finishPanel;
    
    public void Finish()
    {
        finishPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Lost()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
}
