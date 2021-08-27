using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    public AudioSource clip;
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject ganarPanel;
    LevelManager levelManager;

    private void Awake()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent(typeof(LevelManager)) as LevelManager;
    }

    public void PausePanel()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void GameOverPanel()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void GanarPanel()
    {
        Time.timeScale = 0;
        ganarPanel.SetActive(true);
        levelManager.DesbloquearNivel();
    }
    public void Return()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void OptionsPanel()
    {
        //Music and Sound ,Google Play ,Etc.
    }

    public void GoMainMenu()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene("Main Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlaySoundButton()
    {
        clip.Play();
    }

    public void ResetLevel()
    {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoLevelSelect()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelect");
    }

}
