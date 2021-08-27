using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            // Destroy(collision.gameObject); // Esto destruye al jugador la idea es hacerlo con vidas
            collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();
        }
    }
}
