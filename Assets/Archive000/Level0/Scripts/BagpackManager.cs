using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagpackManager : MonoBehaviour
{
    public static BagpackManager Instance;

    private void Awake()
    {
        Instance = this;
    }


    public List<Slot> slots;


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
        foreach(var slot in this.slots)
        {
            if(slot.index == 0)
            {
                slot.AddItem(item);
                return;
            }
        }
    }


}
