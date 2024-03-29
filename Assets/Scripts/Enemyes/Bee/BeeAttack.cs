﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAttack : MonoBehaviour
{

    public Animator animator;
    public float distanceRaycast = 0.5f;
    private float cooldownAttack = 1.5f;
    private float actualCooldownAttack;
    public GameObject beeBullet;

    
    void Start()
    {
        actualCooldownAttack = 0;
    }

    
    void Update()
    {
        actualCooldownAttack -= Time.deltaTime;
        
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.down, distanceRaycast);

        if (hit2D.collider!=null)
        {
            if (hit2D.collider.CompareTag("Player") && actualCooldownAttack<0)
            {
                Invoke("LaunchBeeBullet", 0.5f);
                animator.Play("Attack");
                actualCooldownAttack = cooldownAttack;
            }
        }
    }

    void LaunchBeeBullet()
    {
        GameObject newBullet;

        newBullet = Instantiate(beeBullet, transform.position, transform.rotation);
    }

}
