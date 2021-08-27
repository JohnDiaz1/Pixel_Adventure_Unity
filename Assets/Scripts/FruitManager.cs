using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class FruitManager : MonoBehaviour
{

    private int totalFruits;
    private int collectedFruits;
    private int restFruits;
    public TextMeshProUGUI textMesh;
    public UIManager ganar;

    private void Start()
    {
        totalFruits = transform.childCount;
    }

    private void Update()
    {
        restFruits = transform.childCount;
        AllFruitsCollected();
        collectedFruits = totalFruits - restFruits;
        textMesh.text = collectedFruits.ToString() + " / " + totalFruits.ToString();  //Cambiar Esto el totalFruits va de ultimo el contador debe empezar desde cero
    }

   public void AllFruitsCollected()
    {
        if (transform.childCount==0)
        {
            Invoke("ChangeScene", 1);
        }
    }

    void ChangeScene()
    {
        ganar.GanarPanel();
        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
