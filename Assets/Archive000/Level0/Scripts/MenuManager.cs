using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class MenuManager : MonoBehaviour
{

    public static MenuManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public CinemachineVirtualCamera m_Camera;

    public List<GameObject> pages;
    public int index;
    public Button buttonLeft;
    public Button buttonRight;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GotoLeft()
    {
        if (index == 0) return;
        //pages[index].gameObject.SetActive(false);
        //index--;
        //pages[index].gameObject.SetActive(true);
        //pages[index].transform.localPosition
        //    = Vector3.zero;
        //m_Camera.transform.position = pages[index].transform.position - new Vector3(0,0,10);


        index--;
        m_Camera.LookAt = pages[index].transform;
    }


    public void GotoRight()
    {
        if (index == pages.Count-1) return;
        //pages[index].gameObject.SetActive(false);
        //index++;
        //pages[index].gameObject.SetActive(true);
        //pages[index].transform.localPosition = Vector3.zero;
        //m_Camera.transform.position = pages[index].transform.position - new Vector3(0, 0, 10);

        index++;
        m_Camera.LookAt = pages[index].transform;
    }




}
