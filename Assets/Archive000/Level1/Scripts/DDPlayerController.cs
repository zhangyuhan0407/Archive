using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDPlayerController : MonoBehaviour
{
    Animator ani;
    Rigidbody2D rig;

    public float speedWalk;
    public float speedJump;

    AudioSource audioSource;

    public AudioClip clipFootStep;
    public AudioClip clipStair;
    public AudioClip clipJump;

    float originalScale;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        originalScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        Jump();

    }


    public void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rig.velocity = new Vector2(-speedWalk, rig.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1) * originalScale;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rig.velocity = new Vector2(speedWalk, rig.velocity.y);
            transform.localScale = new Vector3(1, 1, 1) * originalScale;
        }
        else
        {
            rig.velocity = new Vector2(0, rig.velocity.y);
        }

        if (Mathf.Abs(rig.velocity.x) > 0.01f)
        {
            ani.SetBool("Walk", true);
            if(audioSource.isPlaying == false)
            {
                audioSource.clip = clipFootStep;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        else
        {
            ani.SetBool("Walk", false);
            if(audioSource.clip == clipFootStep)
            {
                audioSource.Stop();
            }
        }
    }


    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig.velocity = new Vector2(rig.velocity.x, speedJump);
            ani.SetBool("Jump", true);
        }

        if(rig.velocity.y >= 0)
        {
            rig.gravityScale = 1;
        }
        else
        {
            rig.gravityScale = 2;
        }

        if (Mathf.Abs(rig.velocity.y) > 0.01f)
        {
            ani.SetBool("Jump", true);
        }
        else
        {
            ani.SetBool("Jump", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogWarning("Collision " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Ground")) {
            audioSource.clip = clipJump;
            audioSource.loop = false;
            audioSource.Play();
            Debug.Log("Player Sound: clipJump");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogWarning("Trigger " + collision.gameObject.name);
    }


    public void Freeze()
    {
        rig.velocity = Vector2.zero;
        rig.gravityScale = 0;
    }


    public void Unfreeze()
    {
        rig.gravityScale = 1;
    }

}
