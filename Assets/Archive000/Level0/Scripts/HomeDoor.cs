using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HomeDoor : MonoBehaviour, IPointerClickHandler
{

    public GameObject panelHome;


    // Start is called before the first frame update
    void Start()
    {
        panelHome.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("asd");
        panelHome.gameObject.SetActive(true);
    }

}
