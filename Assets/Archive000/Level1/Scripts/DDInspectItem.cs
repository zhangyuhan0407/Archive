using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDInspectItem : MonoBehaviour
{

    public static DDInspectItem Instance;

    private void Awake()
    {
        Instance = this;
    }


    public Transform rootInspectItem;

    public DDItem itemOnWorld;
    public GameObject inspectingItem;

    bool isOpened;

    // Start is called before the first frame update
    void Start()
    {
        rootInspectItem.gameObject.SetActive(false);
        isOpened = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(rootInspectItem.gameObject.activeSelf == false)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isOpened == false)
            {
                isOpened = true;
                PlayOpenAnimation();
            }
            else
            {
                Destroy(inspectingItem);
                Destroy(itemOnWorld.gameObject);
                rootInspectItem.gameObject.SetActive(false);
            }
        }
    }


    public void InspectItem(DDItem itemOnWorld)
    {
        this.itemOnWorld = itemOnWorld;
        rootInspectItem.gameObject.SetActive(true);
        GameObject prefab = Resources.Load<GameObject>("Prefabs/" + itemOnWorld.itemName);
        GameObject item = Instantiate(prefab);
        item.transform.SetParent(rootInspectItem);
        item.transform.localPosition = Vector3.zero;
        inspectingItem = item;
    }


    public void PlayOpenAnimation()
    {
        inspectingItem.GetComponent<Animator>().Play("Open");
    }

}
