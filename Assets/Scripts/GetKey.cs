using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{

    public static bool isKeyCollected;

    private void Start()
    {
        isKeyCollected = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isKeyCollected = true;
        }
    }
}
