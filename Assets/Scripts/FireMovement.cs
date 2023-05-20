using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMovement : MonoBehaviour
{

    public float fireBallSpeed;

    void Update()
    {
        transform.position = new Vector2(transform.position.x + fireBallSpeed, transform.position.y + 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
