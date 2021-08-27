using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveAndLoad : MonoBehaviour
{

    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;

    private string ruteFile;
    static bool firstTime = true;

    private void Awake()
    {
        ruteFile = Application.persistentDataPath + "/datos.dat";
        if (firstTime)
        {
            Load();
            firstTime = false;
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(ruteFile);
        DataSave data = new DataSave(LevelManager.levelsUnlocked);
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(ruteFile))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(ruteFile, FileMode.Open);
            DataSave data = (DataSave)bf.Deserialize(file);
            LevelManager.levelsUnlocked = data.levelsUnlocked;
        }
        else
        {
            LevelManager.levelsUnlocked = 0;
        }
    }

    public void CambioDePanel(int panelActual)
    {
        switch (panelActual)
        {
            case 1:
                panel2.SetActive(false);
                panel3.SetActive(false);
                panel1.SetActive(true);    
                break;

            case 2:
                panel1.SetActive(false);
                panel3.SetActive(false);
                panel2.SetActive(true);
                
                break;

            case 3:
                panel2.SetActive(false);
                panel3.SetActive(true);
                break;

            default:
                break;
        } 
    }

}

[System.Serializable]
class DataSave
{
    public int levelsUnlocked;

    public DataSave(int levelsUnlocked_)
    {
        levelsUnlocked = levelsUnlocked_;
    }

}
