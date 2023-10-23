using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDCamera : MonoBehaviour
{
    public GameObject anyObject;

    // Start is called before the first frame update
    void Start()
    {
        anyObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var pos = anyObject.transform.position - new Vector3(0, 0, 10);
        
        if(pos.x < -8.33f)
        {
            pos.x = -8.33f;
        }

        if (pos.x > 0.86f)
        {
            pos.x = 0.86f;
        }

        if (pos.y < -2f)
        {
            pos.y = -2f;
        }

        if (pos.y > 6.12f)
        {
            pos.y = 6.12f;
        }

        transform.position = pos;
    }


}
