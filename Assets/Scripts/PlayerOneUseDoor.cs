using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneUseDoor : MonoBehaviour
{
    [SerializeField] private GameObject playerOne;
    public static bool hasPlayerOneUsedDoor;

    private void Start()
    {
        hasPlayerOneUsedDoor = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (InsertKeyToDoor.doorOpen == true)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    hasPlayerOneUsedDoor = true;
                    playerOne.SetActive(false);
                }
            }
        }
    }
}
