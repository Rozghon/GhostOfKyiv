using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decoy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") 
        {
            EnemyMovement _enemyMovement = collision.GetComponent<EnemyMovement>();
            _enemyMovement.StartDecoy();
        }
    }
}
