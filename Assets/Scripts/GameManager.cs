using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject losePanel;
    public GameObject finishPanel;
    public GameObject StartPanel;
    public GameObject MenuPanel;
    public AudioSource inGameMusic;
    public AudioSource menuMusic;

    void Start()
    {
        StartPanel.SetActive(true);
        menuMusic.Play();
        Time.timeScale = 0f;
    }
    
    public void Finish()
    {
        finishPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    

    public void Menu()
    {
        MenuPanel.SetActive(true);
        StartPanel.SetActive(false);
        Time.timeScale = 0f;
    }

    public void BackStart()
    {
        MenuPanel.SetActive(false);
        StartPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        StartPanel.SetActive(false);
        menuMusic.Stop();
        inGameMusic.Play();
        Time.timeScale = 1f;
    }

    public void Lost()
    {
        losePanel.SetActive(true);
        inGameMusic.Stop();
        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
}
