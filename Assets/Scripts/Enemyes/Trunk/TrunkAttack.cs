using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkAttack : MonoBehaviour
{
    public Animator animator;
    private float cooldownAttack = 0.5f;
    private bool atacando;
    private float actualCooldownAttack;
    public GameObject trunkBullet;

    [SerializeField] private float distanciaAtaque;

    void Start()
    {
        actualCooldownAttack = 0;
    }


    void Update()
    {
        actualCooldownAttack -= Time.deltaTime;

    }

   /* private void FixedUpdate()
    {

        if (hit2D.collider != null)
        {
            if (hit2D.collider.CompareTag("Player"))
            {
                animator.SetBool("Attack", true);
                Invoke("LaunchBullet", 0.3f);
                actualCooldownAttack = cooldownAttack;
            }
        }
    }*/

    void LaunchBullet()
    {
        GameObject newBullet;

        newBullet = Instantiate(trunkBullet, transform.position, transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && actualCooldownAttack < 0)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Idle", false);
            animator.Play("Attack");
            animator.SetBool("Attack", true);
            //Invoke("LaunchBullet", 0.3f);
            actualCooldownAttack = cooldownAttack;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && actualCooldownAttack < 0)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Idle", false);
            animator.Play("Attack");
            animator.SetBool("Attack", true);
            Invoke("LaunchBullet", 0.3f);
            actualCooldownAttack = cooldownAttack;

        }
        else
        {
            animator.SetBool("Attack", false);
        }

    }

}
