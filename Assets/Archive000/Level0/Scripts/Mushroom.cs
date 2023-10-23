using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mushroom : MonoBehaviour, IPointerClickHandler
{

    public int index;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        BagpackManager.Instance.AddItem(this);
        Destroy(gameObject);
    }


}
