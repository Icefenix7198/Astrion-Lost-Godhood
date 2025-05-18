using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    int maxPlayerHealth;

    public GameObject canvasUI;
    public List<Image> hearthSprites;

    int lifeQuantity;

    public bool activateSprites;

    public GameObject spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        lifeQuantity = playerHealth / hearthSprites.Count;
        maxPlayerHealth = playerHealth;

        activateSprites = false;
        DontDestroyOnLoad(canvasUI);
    }

    // Update is called once per frame
    void Update()
    {
        if (activateSprites)
        {
            for (int i = 0; i < hearthSprites.Count; i++)
            {
                if (playerHealth <= lifeQuantity * i)
                {
                    hearthSprites[i].gameObject.SetActive(false);
                }
                else
                {
                    hearthSprites[i].gameObject.SetActive(true);    
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            TakeDamage(10);
        }

        if(spawnPosition == null)
        {
            spawnPosition = GameObject.Find("SpawnPosition").gameObject;
        }
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;

        if(playerHealth <= 0)
        {
            this.transform.position = spawnPosition.transform.position;
            playerHealth = maxPlayerHealth;
        }
    }

    public void ActivateSprites()
    {
        activateSprites = true;
    }
}
