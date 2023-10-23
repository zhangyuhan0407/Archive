using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDBrick : MonoBehaviour
{

    public Transform originalPosition;
    public Transform destinationPosition;

    float counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
    }


    public void MoveForward()
    {
        counter = 0;
        StartCoroutine(MoveForward_Animation());
    }

    public void MoveBackward()
    {
        counter = 0;
        StartCoroutine(MoveBackward_Animation());
    }

    IEnumerator MoveForward_Animation()
    {
        while(counter < 1)
        {
            transform.position = Vector3.Lerp(transform.position, destinationPosition.position, 0.02f);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator MoveBackward_Animation()
    {
        while (counter < 1)
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition.position, 0.02f);
            yield return new WaitForEndOfFrame();
        }
    }

}
