using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;

    public GameObject canvasUI;
    public List<Image> hearthSprites;

    int lifeQuantity;

    public bool activateSprites;

    // Start is called before the first frame update
    void Start()
    {
        lifeQuantity = playerHealth / hearthSprites.Count;

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
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
    }

    public void ActivateSprites()
    {
        activateSprites = true;
    }
}
