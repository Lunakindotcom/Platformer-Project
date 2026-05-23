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
    public AudioSource loseMusic;
    public AudioSource winMusic;
    public AudioSource walkingSoundEffect;

    void Start()
    {
        walkingSoundEffect.Pause();
        StartPanel.SetActive(true);
        menuMusic.Play();
        Time.timeScale = 0f;
    }
    
    public void Finish()
    {
        inGameMusic.Stop();
        winMusic.Play();
        walkingSoundEffect.Stop();
        finishPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    

    public void Menu()
    {
        walkingSoundEffect.Pause();
        MenuPanel.SetActive(true);
        StartPanel.SetActive(false);
        Time.timeScale = 0f;
    }

    public void BackStart()
    {
        walkingSoundEffect.Pause();
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
        inGameMusic.Stop();
        losePanel.SetActive(true);
        loseMusic.Play();
        walkingSoundEffect.Stop(); ;
        Time.timeScale = 0f;
        
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
}
