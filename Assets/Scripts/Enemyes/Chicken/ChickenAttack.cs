using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenAttack : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    Transform player;
    [SerializeField]
    Transform enemy;
 
         void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                animator.Play("Run");
                enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, player.transform.position, 1 * Time.deltaTime);
            }
        }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.Play("Run");
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, player.transform.position, 1 * Time.deltaTime);

        }

    }

        /*
            [SerializeField]
             Transform player;

             [SerializeField]
             Transform castPoint;

             [SerializeField]
             float attackRange;

             [SerializeField]
             float speed;

             bool isFacingLeft = false;
             private bool isSearching  = false;
            private bool isAgro = false;  //Agro quiere decir enojado, es dicr que detecto el objeto

             //Rigidbody2D rigidbody2d;

             //public Transform head;
             public Animator animator;

            private void Update()
            {

                if (CanSeePlayer(attackRange))
                {
                    isAgro = true;
                    // ChasePlayer();
                }
                else
                {
                    if (isAgro)
                    {

                        if (!isSearching)
                        {
                            isSearching = true;
                            StopChasingPlayer();
                            //Invoke("StopChasingPlayer", 3);
                        }
                    }
                }

                if (isAgro)
                {
                    ChasePlayer();
                }
            }


                 //distacia player

               /*  float distPlayer = Vector2.Distance(transform.position, player.position);

                 if (distPlayer < attackRange)
                 {
                     ChasePlayer();
                 }
                 else
                 {
                     StopChasingPlayer();
                 }

             }

             bool CanSeePlayer(float distance)
             {
                 bool val = false;
                 var castDist = distance;

                if (isFacingLeft)
                 {
                     castDist = -distance;
                 }

                 Vector2 endPos = castPoint.position + Vector3.right * castDist;
                 RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Action"));

                 Vector2 finalPos = castPoint.position + Vector3.left * castDist;
                 RaycastHit2D otro = Physics2D.Linecast(castPoint.position, finalPos, 1 << LayerMask.NameToLayer("Action"));



                 if (hit.collider != null)
                 {
                     if (hit.collider.gameObject.CompareTag("Player"))
                     {
                         val = true;
                     }
                     else
                     {
                         val = false;
                     }
                     Debug.DrawLine(castPoint.position, hit.point, Color.red);
                     //Debug.DrawLine(castPoint.position, otro.point, Color.red);

                 } 
                 else if (otro.collider != null)
                 {
                     if (otro.collider.gameObject.CompareTag("Player"))
                     {
                         val = true;
                     }
                     else
                     {
                         val = false;
                     }
                     Debug.DrawLine(castPoint.position, hit.point, Color.red);
                     //Debug.DrawLine(castPoint.position, otro.point, Color.red);
                 }
                 else
                 {
                     Debug.DrawLine(castPoint.position, endPos, Color.yellow);
                     // Debug.DrawLine(castPoint.position, finalPos, Color.yellow);
                 }

                 return val;
             }

             void ChasePlayer()
             {

                 if (transform.position.x < player.position.x)
                 {
                     //Se mueve a la derecha
                     // rigidbody2d.velocity = new Vector2(moveSpeed, 0);
                     transform.localScale = new Vector2(1, 1);
                     transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                     //isFacingLeft = false;
                 }
                 else
                 {
                     //Se mueve a la izquierda
                     //rigidbody2d.velocity = new Vector2(-speed, 0);
                     transform.localScale = new Vector2(-1, 1);
                     transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                     //isFacingLeft = true;
                 }

                 animator.Play("Run");

             }

             void StopChasingPlayer()
             {
                 isAgro = false;
                 isSearching = false;
                 transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 0);
             }*/
    }
