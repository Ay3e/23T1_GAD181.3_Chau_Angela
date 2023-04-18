using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCountdown : MonoBehaviour
{
    public float countdown;
    public GameObject p1Tutorial;
    public GameObject p2Tutorial;
    void Start()
    {
        countdown = 4f;

    }

    // Update is called once per frame
    void Update()
    {
        countdown -= 1 * Time.deltaTime;
        if(countdown <= 0)
        {
            p1Tutorial.SetActive(false);
            p2Tutorial.SetActive(false);
        }
    }
}
