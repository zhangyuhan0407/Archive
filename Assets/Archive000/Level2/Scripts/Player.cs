using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    public bool isEnabled;

    public List<GameObject> objs;

    Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnabled) return;

        if (Input.GetKey(KeyCode.Q))
        {
            RotateLeft();
        }

        if (Input.GetKey(KeyCode.E))
        {
            RotateRight();
        }
    }



    public void RotateLeft()
    {
        foreach (var obj in this.objs)
        {
            obj.transform.RotateAround(transform.position, new Vector3(0, 0, -1), speed * Time.deltaTime);
        }
    }

    public void RotateRight()
    {
        foreach (var obj in this.objs)
        {
            obj.transform.RotateAround(transform.position, new Vector3(0, 0, 1), speed * Time.deltaTime);
        }
    }


    public void SetEnabled(bool flag)
    {
        if (flag)
        {
            isEnabled = true;
            this.GetComponent<Rigidbody2D>().gravityScale = -0.05f;
            this.GetComponent<BoxCollider2D>().enabled = true;
            //ani.Play("Swim");
            ani.speed = 1f;
        }
        else
        {
            isEnabled = false;
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.GetComponent<Rigidbody2D>().gravityScale = 0f;
            this.GetComponent<BoxCollider2D>().enabled = false;
            // ani.Play("Walk");
            ani.speed = 0.5f;
        }
    }


}
