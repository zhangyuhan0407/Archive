using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * *****
 * 1�����ް�·���ƶ�
 * 2�����첻�ƶ��������ƶ�
 * 3���������������ʵʱ���ڹ�������
 * 
 * 
 * 
 * 
 * 1�����ް�·���ƶ�
 *  a������������һ��·�����У�List<Transform> path��
 *  b����������ǰĿ�ĵ���ţ�index��
 *  c���������ƶ�����ǰĿ�ĵأ�MoveToPoint(int index)��
 *  b������������Ƿ񵽴ﵱǰĿ�ĵأ�CheckHasReachPoint()��
 * 
 * 
 * 
 * 
 */




public class DDNightmare : MonoBehaviour
{

    public List<Transform> path;        //����Ѳ��·��������
    public int index;       //��ǰĿ�ĵص���ţ�һ�����֣�
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


        Vector3 dir = (path[index].position - transform.position).normalized;   //�����ķ�������
        transform.position += dir * speed * Time.deltaTime;
        //transform.LookAt(path[index].position);
        //transform.right = -path[index].position;
    }


    public bool CheckHasReachPoint()
    {
        var distance = (transform.position - path[index].position).magnitude;   // ����ģ��
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
