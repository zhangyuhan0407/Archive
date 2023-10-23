using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDStair : MonoBehaviour
{

    public GameObject player;
    Collider2D col;
    public bool state;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (col == null) return;

        //如果玩家在台阶上面
        if(transform.position.y +col.offset.y  > player.transform.position.y)
        {
            state = false;
            col.isTrigger = true;
        }
        else
        {
            state = true;
            col.isTrigger = false;
        }
    }



}
