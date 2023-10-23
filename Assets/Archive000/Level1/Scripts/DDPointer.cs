using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDPointer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DDManagerLevel_1.Instance.isDay)
        {

        }
        else
        {
            transform.Rotate(new Vector3(0, 0, 0.02f));
        }
    }
}
