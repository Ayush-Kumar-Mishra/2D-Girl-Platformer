using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public Rigidbody2D rb;
    public static bool isGrounded;
    public TMP_Text scoreText;
    public TMP_Text scoreText2;
    public TMP_Text lvlDisplay;
    int score;
    public int scoreCount;
    public Animator anim;
    public GameObject Image;
    public GameObject portal;
    public GameObject fireBall;
    public AudioSource jumpAudio;
    public AudioSource shootAudio;

    void Start()
    {
        transform.position = new Vector2(-6,-2);
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -8.5f, 82.5f),transform.position.y);
        rb.velocity = new Vector2(rb.velocity.x + speed*horizontalInput,rb.velocity.y + 0);
        if (Input.GetKeyDown(KeyCode.Space) & isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }

        scoreText.text = score.ToString();
        scoreText2.text = score.ToString();

        if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("isJumping", true);
            jumpAudio.Play();
        }
        else
        {
            anim.SetBool("isJumping", false);
        }

        if (score >= scoreCount)
        {
            portal.gameObject.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            var Clone = Instantiate(fireBall, transform.position, Quaternion.identity);
            shootAudio.Play();
            Destroy(Clone, 2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            score++;
        }

        /*else if (collision.gameObject.tag == "MovingGround")
        {
            this.gameObject.transform.SetParent(collision.transform);
        }*/
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "MovingGround")
        {
            rb.gravityScale = 0;
        }
    }*/

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "MovingGround")
        {
            rb.gravityScale = 1;
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "deathPoint"||collision.gameObject.tag == "Enemy")
        {
            anim.SetBool("isDead", true);
            Destroy(scoreText.gameObject);
            Destroy(this.gameObject,1f);
            Destroy(lvlDisplay.gameObject);
            Image.gameObject.SetActive(true);
            StartCoroutine(animTimer());
        }
    }

    IEnumerator animTimer()
    {
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0;
    }
}
