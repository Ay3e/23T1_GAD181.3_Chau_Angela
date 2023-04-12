using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKeyP2 : MonoBehaviour
{
    private bool isFollowing;

    public static bool playerOneHasKey;

    public float followSpeed;

    public Transform followTargetP2;

    private void Update()
    {
        if (isFollowing)
        {
            transform.position = Vector3.Lerp(transform.position, followTargetP2.position, followSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!isFollowing)
            {
                MoveArrowKeys thePlayerTwo = FindObjectOfType<MoveArrowKeys>();
                followTargetP2 = thePlayerTwo.keyFollowPointTwo;
                isFollowing = true;
                thePlayerTwo.followingKey = this;
            }
        }
    }
}
