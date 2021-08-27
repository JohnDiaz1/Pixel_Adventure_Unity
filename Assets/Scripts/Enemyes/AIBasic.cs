using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBasic : MonoBehaviour
{

    public Animator animator;
    public SpriteRenderer spriteRender;
    public float speed = 0.5f;
    private float waitTime;

    public float startWaitTime = 2;
    private int i = 0;

    private Vector2 actualPos;

    public Transform[] moveSpots; 

    void Start()
    {
        waitTime = startWaitTime;
    }

    void Update()
    {
        StartCoroutine(CheckEnemyMoving());

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[i].transform.position)<0.1f)
        {
            if (waitTime<=0)
            {
                if (moveSpots[i] != moveSpots[moveSpots.Length-1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }

                waitTime = startWaitTime;

            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

    }

    IEnumerator CheckEnemyMoving()
    {
        actualPos = transform.position;

        yield return new WaitForSeconds(0.5f);

        if (transform.position.x > actualPos.x)
        {
            //spriteRender.flipX = true;
            transform.localScale = new Vector2(-1, 1);
            //transform.rotation.y = new Vector2(0, 180);
            animator.SetBool("Idle", false);
        }
        else if(transform.position.x < actualPos.x)
        {
            //spriteRender.flipX = false;
            transform.localScale = new Vector2(1, 1);
            animator.SetBool("Idle", false);
        }
        else if(transform.position.x == actualPos.x)
        {
            animator.SetBool("Idle", true);
        }
    }

}
