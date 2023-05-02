using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{

    public GameObject WallBlock;
    public GameObject WallBlock2;
    public bool onButton = false;
    public bool stage2Ready = false;
    private int pressedTracker = 0;
    public GameObject buttonDown;
    public GameObject buttonUp;

    [SerializeField] private AudioSource pressedButtonSoundEffect;
    [SerializeField] private ParticleSystem particleEffect;

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
            buttonUp.GetComponent<SpriteRenderer>().enabled = false;
            buttonDown.SetActive(true);
            pressedTracker++;
            if(pressedTracker == 1) 
            {
                pressedButtonSoundEffect.Play();
                particleEffect.Play();
            }
            onButton = false;
            WallBlock.SetActive(false);
        }
        if(stage2Ready == true)
        {
            WallBlock2.SetActive(false);
        }

    }
}
    
