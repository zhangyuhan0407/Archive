using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public int index;
    public Mushroom item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(Mushroom item)
    {
        this.item = item;
        this.index = item.index;
        item.transform.SetParent(transform);
        item.transform.localPosition = Vector3.zero;
        this.GetComponent<Image>().enabled = true;
        this.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icon" + item.index);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (this.index == 0) return;
        SceneManager.LoadScene("Scenes/Level" + index);

    }

}
