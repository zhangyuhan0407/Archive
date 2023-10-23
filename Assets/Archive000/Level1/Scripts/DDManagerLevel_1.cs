using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DDDirection
{
    North,South,East,West
}


public class DDManagerLevel_1 : MonoBehaviour
{
    public static DDManagerLevel_1 Instance;

    private void Awake()
    {
        Instance = this;
    }

    public bool isDay;

    public GameObject worldDay;
    public GameObject worldNight;
    public GameObject world;
    public GameObject player;

    public GameObject centerCamera;

    public DDDirection dir;

    public GameObject collidersStairs;

    public Transform cam;


    // Start is called before the first frame update
    void Start()
    {
        isDay = true;
        worldDay.gameObject.SetActive(true);
        worldNight.gameObject.SetActive(false);

        player = GameObject.FindObjectOfType<DDPlayerController>().gameObject;

        dir = DDDirection.North;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isDay)
            {
                worldDay.gameObject.SetActive(false);
                worldNight.gameObject.SetActive(true);
            }
            else
            {
                worldDay.gameObject.SetActive(true);
                worldNight.gameObject.SetActive(false);
            }
            isDay = !isDay;
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            DDSoundManager.Instance.PlaySound(DDSoundManager.Instance.clipLayInBed);
            StartCoroutine(RotateAnimation_Forward());
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            DDSoundManager.Instance.PlaySound(DDSoundManager.Instance.clipLayInBed);
            StartCoroutine(RotateAnimation_Backward());
        }


        //东、西方向朝上时，关闭碰撞体
        if(this.dir == DDDirection.East || this.dir == DDDirection.West)
        {
            //找到所有的碰撞体
            var colliders = collidersStairs.GetComponentsInChildren<Collider2D>();
            //foreach（循环遍历对于每一个碰撞体）
            foreach(var col in colliders)
            {
                //对于其中的每一个碰撞体，关闭碰撞体
                col.enabled = false;
            }
        }
        else
        {
            var colliders = collidersStairs.GetComponentsInChildren<Collider2D>();
            foreach (var col in colliders)
            {
                col.enabled = true;
            }
        }

    }


    IEnumerator RotateAnimation_Forward()
    {
        GameObject.FindObjectOfType<DDPlayerController>().Freeze();

        int i = 0;
        while (i++ < 90)
        {
            worldDay.transform.RotateAround(centerCamera.transform.position, Vector3.forward, 1);
            worldNight.transform.RotateAround(centerCamera.transform.position, Vector3.forward, 1);
            world.transform.RotateAround(centerCamera.transform.position, Vector3.forward, 1);
            player.transform.RotateAround(centerCamera.transform.position, Vector3.forward, 1);
            player.transform.RotateAround(player.transform.position, Vector3.back, 1);
            yield return new WaitForEndOfFrame();
        }

        if(this.dir == DDDirection.North)
        {
            this.dir = DDDirection.West;
        }
        else if (this.dir == DDDirection.West)
        {
            this.dir = DDDirection.South;
        }
        else if (this.dir == DDDirection.South)
        {
            this.dir = DDDirection.East;
        }
        else if (this.dir == DDDirection.East)
        {
            this.dir = DDDirection.North;
        }

        GameObject.FindObjectOfType<DDPlayerController>().Unfreeze();
    }

    IEnumerator RotateAnimation_Backward()
    {

        GameObject.FindObjectOfType<DDPlayerController>().Freeze();

        int i = 0;
        while (i++ < 90)
        {
            worldDay.transform.RotateAround(centerCamera.transform.position, Vector3.back, 1);
            worldNight.transform.RotateAround(centerCamera.transform.position, Vector3.back, 1);
            world.transform.RotateAround(centerCamera.transform.position, Vector3.back, 1);
            player.transform.RotateAround(centerCamera.transform.position, Vector3.back, 1);
            player.transform.RotateAround(player.transform.position, Vector3.forward, 1);
            yield return new WaitForEndOfFrame();
        }

        if (this.dir == DDDirection.North)
        {
            this.dir = DDDirection.East;
        }
        else if (this.dir == DDDirection.East)
        {
            this.dir = DDDirection.South;
        }
        else if (this.dir == DDDirection.South)
        {
            this.dir = DDDirection.West;
        }
        else if (this.dir == DDDirection.West)
        {
            this.dir = DDDirection.North;
        }

        GameObject.FindObjectOfType<DDPlayerController>().Unfreeze();
    }
}
