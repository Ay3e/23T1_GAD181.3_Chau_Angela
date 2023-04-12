using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKeyP1 : MonoBehaviour
{
    private bool isFollowingP1;

    public float followSpeed;

    public Transform followTargetP1;

    private void Update()
    {
        if (isFollowingP1)
        {
            transform.position = Vector3.Lerp(transform.position, followTargetP1.position, followSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (!isFollowingP1)
            {
                MoveWASD thePlayerOne = FindObjectOfType<MoveWASD>();
                followTargetP1 = thePlayerOne.keyFollowPointOne;
                isFollowingP1 = true;
                thePlayerOne.followingKey = this;
            }
        }
    }
}
