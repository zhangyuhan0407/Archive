using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDHint : MonoBehaviour
{

    public string hintName;

    public bool hasHint;

    // Start is called before the first frame update
    void Start()
    {
        hasHint = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasHint) return;

        if(collision.gameObject.CompareTag("Player"))
        {
            hasHint = true;
            DDHintController.Instance.ShowHint(hintName);
        }
    }

}
