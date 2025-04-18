using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 0.6f;

    public string SceneName; // New scene to change to.
    [SerializeField] bool requiresInteraction = false; // If its a door that requires up interction
    public Vector2 positionToSpawn;
    [SerializeField] GameObject Player;

    [SerializeField] List<GameObject> notDestoyOnLoad;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player"); // Maybe it would be best if the script was on the player and it detected the TP wall
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // In case requiresInteraction is true it would be needed to hover up to activate the change scene
        if (collision.gameObject == Player && !requiresInteraction) // If collides with the player change to the scene on the script. (I don't know if assigning the player is the best way to this)
        {
            try // If the method fails for any reason do the method in the catch area
            {
                Player.SetActive(false);
                SceneTransition();
            }
            catch
            {
                SceneManager.LoadScene("SampleScene");// Error handler function [It doesn't work actually, it just fails]
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (requiresInteraction)
        {
            if (collision.gameObject == Player)
            {
                // Show UI to player to note him that he must press up to enter
                if (Input.GetAxis("Vertical") > 0.6f)
                {
                    SceneTransition();
                }
            }
        }
    }

    void SceneTransition()
    {
        // Don't Destroy The Player to have only one player on the game, not one per scene
        DontDestroyOnLoad(Player);

        //Change to the scene written on the Script
        StartCoroutine(LoadLevel());        
    }

    IEnumerator LoadLevel() 
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(SceneName);
        
        //Set the position on the new room depending on the door
        Vector3 vecPos = new Vector3(positionToSpawn.x, positionToSpawn.y, 0);
        Player.transform.position = vecPos;

        Player.SetActive(true);
    }
}
