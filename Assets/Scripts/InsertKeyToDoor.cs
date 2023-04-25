using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InsertKeyToDoor : MonoBehaviour
{

    private MoveWASD thePlayerOne;

    [SerializeField] private GameObject Closed;
    [SerializeField] private GameObject Opened;

    public bool doorOpen, waitingToOpen;
    private bool isPlayerOneOnTrigger;
    private bool isPlayerTwoOnTrigger;

    [SerializeField] private GameObject playerOne;
    [SerializeField] private GameObject playerTwo;

    [SerializeField] private AudioSource openDoorSoundEffect;

    private void Start()
    {
        Closed.SetActive(true);
        Opened.SetActive(false);
    }

    private void Update()
    {
        thePlayerOne = FindObjectOfType<MoveWASD>();

        //If key is at door position open the door and remove the key from view
        if (waitingToOpen)
        {
            if (Vector3.Distance(thePlayerOne.followingKey.transform.position, transform.position) < 0.1f)
            {
                waitingToOpen = false;

                doorOpen = true;

                Opened.SetActive(true);
                Closed.SetActive(false);

                thePlayerOne.followingKey.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                //thePlayerOne.followingKey = null;
            }
        }
        if (isPlayerOneOnTrigger == true && isPlayerTwoOnTrigger == true && waitingToOpen == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


    //When any player collides with the door and the player has the key then...
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            openDoorSoundEffect.Play();
            thePlayerOne.followingKey.followTargetP1 = transform;
            waitingToOpen = true;

            isPlayerOneOnTrigger = true;
            isPlayerTwoOnTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isPlayerOneOnTrigger = false;
        isPlayerTwoOnTrigger = false;
    }
}
