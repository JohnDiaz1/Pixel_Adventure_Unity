using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    private float waitTime;
    private float waitTimeAttack = 3;
    public Animator animator;
    public GameObject bulletPrefab;
    public Transform launchSpawnPoint;

    private void Start()
    {
        waitTime = waitTimeAttack;
    }

    private void Update()
    {
        if (waitTime<=0)
        {
            waitTime = waitTimeAttack;
            animator.Play("Attack");
            Invoke("LaunchBullet", 0.5f);
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    public void LaunchBullet()
    {
        GameObject newBullet;

        newBullet = Instantiate(bulletPrefab, launchSpawnPoint.position, launchSpawnPoint.rotation);
    }

}
