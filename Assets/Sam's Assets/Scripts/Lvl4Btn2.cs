using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl4Btn2 : MonoBehaviour
{
    public GameObject WallBlock2;
    public bool onButton = false;
    

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        onButton = true;
        
    }
    void Update()
    {
        if (onButton == true)
        {

            WallBlock2.SetActive(false);
        }
    }
}
