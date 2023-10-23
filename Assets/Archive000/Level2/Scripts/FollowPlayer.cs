using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public float offsetZ;
    GameObject player;

    public bool force;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        float z = offsetZ;

        if(force == false)
        {
            if (player.transform.position.x < minX) x = minX;
            if (player.transform.position.x > maxX) x = maxX;
            if (player.transform.position.y < minY) y = minY;
            if (player.transform.position.x > maxY) y = maxY;
        }
        
        transform.position = new Vector3(x,y,z);
    }
}
