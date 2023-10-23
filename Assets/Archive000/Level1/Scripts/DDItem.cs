using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDItem : MonoBehaviour
{
    public bool isPlayerInteractive;
    public string itemName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isPlayerInteractive)
        {
            if(Input.GetKeyDown(KeyCode.Tab))
            {
                DDSoundManager.Instance.PlaySound(DDSoundManager.Instance.clipPickUp);
                DDInspectItem.Instance.InspectItem(this);
            }
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInteractive = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInteractive = false;
        }
    }


}
