using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    public int attackDamage;
    public float attackCooldown;
    float attackTimer;

    bool isPlayer;
    PlayerHealth pH;

    // Start is called before the first frame update
    void Start()
    {
        attackTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayer && pH != null)
        {
            attackTimer += Time.deltaTime;

            if(attackTimer > attackCooldown)
            {
                pH.TakeDamage(attackDamage);
                attackTimer = 0;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isPlayer)
        {
            pH = collision.GetComponent<PlayerHealth>();
            isPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isPlayer)
        {
            isPlayer = false;
            attackTimer = 0;
        }
    }
}
