using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetectors : MonoBehaviour
{
    Combat playerCombat;
    EnemyHealth enemyObj;

    public EnemyHealth SendEnemyCollision()
    {
        if(enemyObj != null)
        {
            return enemyObj;
        }

        return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyObj = collision.GetComponent<EnemyHealth>();
        }
    }
}
