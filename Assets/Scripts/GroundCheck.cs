using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground"|| collision.collider.tag == "MovingGround")
        {
            PlayerMovement.isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground"||collision.collider.tag == "MovingGround")
        {
            PlayerMovement.isGrounded = false;
        }
    }
}
