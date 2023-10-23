using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDTrigger : MonoBehaviour
{

    public DDBrick brick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            brick.MoveForward();
            DDSoundManager.Instance.PlaySound(DDSoundManager.Instance.clipClickTrigger);
        }
    }


}
