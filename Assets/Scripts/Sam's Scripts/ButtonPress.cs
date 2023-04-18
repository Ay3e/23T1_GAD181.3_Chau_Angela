using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{

    public GameObject WallBlock;
    public bool onButton = false;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        onButton = true;
    }

    void Update()
    {
        if(onButton == true)
        {

            WallBlock.SetActive(false);
        }

    }
}
    
