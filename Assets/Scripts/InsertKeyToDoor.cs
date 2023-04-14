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
    private bool isPlayerOnTrigger;
    private bool playerOneIn, playerTwoIn;

    [SerializeField] private GameObject playerOne;
    [SerializeField] private GameObject playerTwo;

    public static int currentSceneNumber = 0;

    private void Start()
    {
        Closed.SetActive(true);
        Opened.SetActive(false);
    }

    private void Update()
    {
        thePlayerOne = FindObjectOfType<MoveWASD>();
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
        if (Input.GetKeyDown(KeyCode.DownArrow) && isPlayerOnTrigger == true && waitingToOpen == false)
        {
            playerTwo.GetComponent<SpriteRenderer>().enabled = false;
            playerTwoIn = true;
        }
        if (Input.GetKeyDown(KeyCode.S) && isPlayerOnTrigger == true && waitingToOpen == false)
        {
            playerOne.GetComponent<SpriteRenderer>().enabled = false;
            playerOneIn = true;
        }
        if (playerTwoIn == true && playerOneIn == true)
        {
            SceneManager.LoadScene(currentSceneNumber++);
        }
        if (playerOneIn == true && playerTwoIn == true)
        {
            SceneManager.LoadScene(currentSceneNumber++);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //if(thePlayerOne.followingKey != null)
            //{
            thePlayerOne.followingKey.followTargetP1 = transform;
            waitingToOpen = true;
            //}
            isPlayerOnTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isPlayerOnTrigger = false;
    }
}