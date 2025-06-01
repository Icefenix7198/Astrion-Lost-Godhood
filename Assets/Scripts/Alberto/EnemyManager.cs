using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<EnemyBasicPathfinding> enemyList;
    public GameObject objToDestroy;

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    EnableEnemies();
        //}
    }

    public void EnableEnemies()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            enemyList[i].enabled = true;
            enemyList[i].transform.GetChild(1).GetComponent<Enemy_Attack>().enabled = true;
        }

        if(objToDestroy != null)
        {
            Destroy(objToDestroy);
        }
    }
}
