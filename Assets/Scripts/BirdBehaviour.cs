using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : MonoBehaviour
{
    private bool playing = false;
    public Rigidbody2D myRB;
    public float velocity = 5f;
    public float rotationspeed = 0f;
    public AudioSource bonkSource;
    public AudioSource wooshSource;
    public AudioSource pipeSource;
    public AudioClip bonk;
    public AudioClip woosh;
    public AudioClip pipe;
    public float pointCooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myRB.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        pointCooldown += Time.deltaTime;
        transform.position = new Vector2(0, transform.position.y);

        if (Input.GetKeyDown("space") && playing == false)
        {
            GameManagerScript.instance.GameRestart();
            playing = true;
            myRB.gravityScale = 1.5f;
        }

        if (Input.GetKeyDown("space") && playing == true)
        {
            myRB.velocity = new Vector2(0,velocity);
            wooshSource.PlayOneShot(woosh);
        }
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, (myRB.velocity.y * rotationspeed) + 5);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        bonkSource.PlayOneShot(bonk);
        playing = false;
        GameManagerScript.instance.GameOver();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (pointCooldown > 2)
        {
            pipeSource.PlayOneShot(pipe);
            GameManagerScript.instance.UpdateScore();
            pointCooldown = 0f;
        }
    }
}
