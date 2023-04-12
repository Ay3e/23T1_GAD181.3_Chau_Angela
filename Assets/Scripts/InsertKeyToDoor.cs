using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InsertKeyToDoor : MonoBehaviour
{

    private MoveWASD thePlayerOne;

    // The Door Game objects
    [SerializeField] private GameObject Closed;
    [SerializeField] private GameObject Opened;

    public static bool doorOpen, waitingToOpen;

    private void Start()
    {
        //Have the door be closed once scene starts
        Closed.SetActive(true);
        Opened.SetActive(false);
    }

    private void Update()
    {
        thePlayerOne = FindObjectOfType<MoveWASD>();
        if (waitingToOpen)
        {
            //When the key position is in the center of the door, unlock it
            if(Vector3.Distance(thePlayerOne.followingKey.transform.position, transform.position) < 0.1f)
            {
                waitingToOpen = false;

                doorOpen = true;

                //Have the door be opened
                Opened.SetActive(true);
                Closed.SetActive(false);
                
                //Destroy the key
                thePlayerOne.followingKey.gameObject.SetActive(false);
                thePlayerOne.followingKey = null;

                //Change the scene when
                if (doorOpen)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //When player is in range of door and the player has the key, move the key to the door
        if(other.tag == "Player")
        {
            if(thePlayerOne.followingKey != null)
            {
                thePlayerOne.followingKey.followTargetP1 = transform;
                waitingToOpen = true;
            }
        }
    }
}
