using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<EnemyBasicPathfinding> enemyList;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            EnableEnemies();
        }
    }

    public void EnableEnemies()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            enemyList[i].enabled = true;
        }
    }
}
