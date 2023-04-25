using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{

    public GameObject WallBlock;
    public GameObject WallBlock2;
    public bool onButton = false;
    public bool stage2Ready = false;
    
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        onButton = true;
        stage2Ready = true;
    }
   

    void Update()
    {
        if(onButton == true)
        {

            WallBlock.SetActive(false);
        }
        if(stage2Ready == true)
        {
            WallBlock2.SetActive(false);
        }

    }
}
    
