using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    [SerializeField] private GameObject Closed;
    [SerializeField] private GameObject Opened;

    private void Start()
    {
        Closed.SetActive(true);
        Opened.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetKey.isKeyCollected == true)
        {
            Closed.SetActive(false);
            Opened.SetActive(true);
        }
    }
}
