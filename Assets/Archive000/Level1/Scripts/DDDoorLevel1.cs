using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDDoorLevel1 : MonoBehaviour
{
    public bool isPlayerBeside;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerBeside)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                DDSoundManager.Instance.PlaySound(DDSoundManager.Instance.clipOpenDoor);
                Invoke("PlaySoundSucceed", 2.0f);
                Invoke("GameSucceed", 5.0f);
            }
        }
    }


    public void PlaySoundSucceed()
    {
        DDSoundManager.Instance.PlaySound(DDSoundManager.Instance.clipSucceed);
    }

    public void GameSucceed()
    {
        SceneManager.LoadScene("Scenes/Level0");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerBeside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerBeside = false;
        }
    }
}
