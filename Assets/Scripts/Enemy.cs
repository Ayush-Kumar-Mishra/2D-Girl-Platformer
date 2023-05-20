using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FireBall")
        {
            Destroy(collision.gameObject);
            anim.SetBool("isDead", true);
            Destroy(this.gameObject, 1f);
        }
    }
}
