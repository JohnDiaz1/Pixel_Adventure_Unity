using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    static public int levelsUnlocked;
    public int actualLevel;
    public Button[] buttonsLevels;
    SaveAndLoad saveAndLoad;

    private void Awake()
    {
        saveAndLoad = GameObject.Find("SaveAndLoad").GetComponent(typeof(SaveAndLoad)) as SaveAndLoad;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "LevelSelect")
        {
            saveAndLoad.Save();
            ActualizarBotones();
        }
    }

    public void OpenLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void DesbloquearNivel()
    {
        if (levelsUnlocked < actualLevel)
        {
            levelsUnlocked = actualLevel;
           // nivelActual++;
        }
    }

    void ActualizarBotones()
    {
        for (int i = 0; i < levelsUnlocked+1; i++)
        {
            buttonsLevels[i].interactable = true;
        }
    }

}
