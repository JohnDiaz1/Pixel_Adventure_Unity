using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSkin : MonoBehaviour
{
    public GameObject skinsPanel;
    public GameObject buttonsPanel;
    public GameObject Player;


    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PanelSkins()
    {
        skinsPanel.gameObject.SetActive(true);
        buttonsPanel.gameObject.SetActive(false);
    }

    public void SetPlayerFrog()
    {
        PlayerPrefs.SetString("PlayerSelected", "Frog");
        ResetPlayerSkin();
    } 

    public void SetPlayerPink()
    {
        PlayerPrefs.SetString("PlayerSelected", "Pink");
        ResetPlayerSkin();
    }

    public void SetPlayerVirtual()
    {
        PlayerPrefs.SetString("PlayerSelected", "Virtual");
        ResetPlayerSkin();
    }

    public void SetPlayerMask()
    {
        PlayerPrefs.SetString("PlayerSelected", "Mask");
        ResetPlayerSkin();
    }

    private void ResetPlayerSkin()
    {
        skinsPanel.gameObject.SetActive(false);
        buttonsPanel.gameObject.SetActive(true);
        Player.GetComponent<PlayerSelect>().ChangePlayerInMenu();
    }

    void Start()
    {
        
    }

   
}
