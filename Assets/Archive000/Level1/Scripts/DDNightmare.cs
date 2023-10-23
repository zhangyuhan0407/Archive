using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * *****
 * 1、怪兽按路径移动
 * 2、白天不移动，晚上移动
 * 3、白天的梯子坐标实时等于怪兽坐标
 * 
 * 
 * 
 * 
 * 1、怪兽按路径移动
 *  a、变量：设置一个路径队列（List<Transform> path）
 *  b、变量：当前目的地序号（index）
 *  c、函数：移动到当前目的地（MoveToPoint(int index)）
 *  b、函数：检查是否到达当前目的地（CheckHasReachPoint()）
 * 
 * 
 * 
 * 
 */




public class DDNightmare : MonoBehaviour
{

    public List<Transform> path;        //所有巡逻路径的坐标
    public int index;       //当前目的地的序号（一个数字）
    public float speed;

    public bool isMoving;
    public GameObject twins;
    Vector3 deltaTwins;

    public List<int> flipXIndexes;
    public List<int> flipYIndexes;

    // Start is called before the first frame update
    void Start()
    {
        index = 1;
        deltaTwins = twins.transform.position - transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        twins.transform.position = transform.position + deltaTwins;
        if (DDManagerLevel_1.Instance.isDay)
        {
            isMoving = false;
            return;
        }

        isMoving = true;
        MoveToPoint(index);
        if(CheckHasReachPoint())
        {
            index += 1;
            index = index % path.Count;
        }
    }


    public void MoveToPoint(int index)
    {
        if (flipXIndexes.Contains(index))
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }


        if (flipYIndexes.Contains(index))
        {
            gameObject.GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipY = false;
        }


        Vector3 dir = (path[index].position - transform.position).normalized;   //向量的方向向量
        transform.position += dir * speed * Time.deltaTime;
        //transform.LookAt(path[index].position);
        //transform.right = -path[index].position;
    }


    public bool CheckHasReachPoint()
    {
        var distance = (transform.position - path[index].position).magnitude;   // 向量模长
        if(distance < 0.05f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
