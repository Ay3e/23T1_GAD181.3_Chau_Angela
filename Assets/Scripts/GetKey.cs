using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    private bool isFollowing;

    public float followSpeed;

    public Transform followTargetP1;
    //public Transform followTargetP2;

    private void Update()
    {
        if (isFollowing)
        {
            transform.position = Vector3.Lerp(transform.position, followTargetP1.position, followSpeed * Time.deltaTime);
            //transform.position = Vector3.Lerp(transform.position, followTargetP2.position, followSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (!isFollowing)
            {
                MoveWASD thePlayerOne = FindObjectOfType<MoveWASD>();
                //MoveArrowKeys thePlayerTwo = FindObjectOfType<MoveArrowKeys>();

                followTargetP1 = thePlayerOne.keyFollowPointOne;
                //followTargetP2 = thePlayerTwo.KeyFollowPointTwo;

                isFollowing = true;
                thePlayerOne.followingKey = this;
            }
        }
    }
}
