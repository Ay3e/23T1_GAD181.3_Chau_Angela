using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl4Btn2 : MonoBehaviour
{
    public GameObject WallBlock2;
    public bool onButton = false;
    [SerializeField] private GameObject buttonUp;
    [SerializeField] private GameObject buttonDown;
    [SerializeField] private AudioSource pressedButtonSoundEffect;
    private int pressedTracker = 0;
    [SerializeField] private ParticleSystem particleEffect;
    [SerializeField] private ParticleSystem particleEffect2;


    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        onButton = true;
        
    }
    void Update()
    {
        if (onButton == true)
        {
            buttonUp.GetComponent<SpriteRenderer>().enabled = false;
            buttonDown.SetActive(true);
            pressedTracker++;
            if (pressedTracker == 1)
            {
                particleEffect.Play();
                particleEffect2.Play();
                pressedButtonSoundEffect.Play();
            }
            WallBlock2.SetActive(false);
        }
    }
}
