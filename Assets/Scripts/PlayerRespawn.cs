using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{

    private float checkPointPositionX, checkPointPositionY;
    public Animator animator;
    public GameObject[] hearts;
    public UIManager gameOver;
    private int life;

    void Start()
    {

        life = hearts.Length;

        if (PlayerPrefs.GetFloat("checkPointPositionX")!=0)
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));
        }
    }

    private void CheckedLife()
    {
        if (life < 1)
        {
            Destroy(hearts[0].gameObject);
            //animator.Play("Hit");
            gameOver.GameOverPanel();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);  Esto reinicia el nivel La idea es mostrar una pantalla de GameOver

        }
        else if (life < 2)
        {
            //animator.Play("Hit");
            Destroy(hearts[1].gameObject);
        }
        else if (life < 3)
        {
          //  animator.Play("Hit");
            Destroy(hearts[2].gameObject);
        }
    }

    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPositionX", x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }

    public void PlayerDamaged()
    {
        animator.Play("Hit");
        life--;
        CheckedLife();
    }

    

}
