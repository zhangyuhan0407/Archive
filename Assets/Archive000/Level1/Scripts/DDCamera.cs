using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDCamera : MonoBehaviour
{
    public GameObject anyObject;

    public float maxX;
    public float minX;
    public float maxY;
    public float minY;

    // Start is called before the first frame update
    void Start()
    {
        anyObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var pos = anyObject.transform.position - new Vector3(0, 0, 10);
        
        if(pos.x < minX)
        {
            pos.x = minX;
        }

        if (pos.x > maxX)
        {
            pos.x = maxX;
        }

        if (pos.y < minY)
        {
            pos.y = minY;
        }

        if (pos.y > maxY)
        {
            pos.y = maxY;
        }

        transform.position = pos;
    }


}
