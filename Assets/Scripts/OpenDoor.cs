using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{

    private MoveWASD thePlayerOne;

    [SerializeField] private GameObject Closed;
    [SerializeField] private GameObject Opened;

    public bool doorOpen, waitingToOpen;

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
            if(Vector3.Distance(thePlayerOne.followingKey.transform.position, transform.position) < 0.1f)
            {
                waitingToOpen = false;

                doorOpen = true;

                Opened.SetActive(true);
                Closed.SetActive(false);

                thePlayerOne.followingKey.gameObject.SetActive(false);
                thePlayerOne.followingKey = null;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
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
