using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LLDialog : MonoBehaviour
{

    public LLDialog next;
    public AudioClip clip;
    public Image icon;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        icon = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    

}
