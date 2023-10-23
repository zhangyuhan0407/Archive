using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bubble : MonoBehaviour
{
    Player player;

    Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        ani.Play(this.gameObject.name + "_Idle");
    }

    // Update is called once per frame
    void Update()
    {
        AbsorbPlayer();

        if(player != null)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //StartCoroutine(TurnLarge());
                TurnLarge2();
            }
        }
    }


    public void TurnLarge2()
    {
        transform.DOScale(10, 1).OnComplete(() =>
        {
            Destroy(gameObject);
            player.SetEnabled(true);
        });
    }


    IEnumerator TurnLarge()
    {
        while(transform.localScale.x < 50)
        {
            float a = transform.localScale.x * 1.01f;
            transform.localScale = new Vector3(a,a,a);
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
        player.SetEnabled(true);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            this.player = collision.gameObject.GetComponent<Player>();
            player.SetEnabled(false);
        }
    }



    public void AbsorbPlayer()
    {
        if (player == null) return;
        float dis = (transform.position - player.transform.position).magnitude;
        if (dis < 0.02) return;
        Vector3 dir = (transform.position - player.transform.position).normalized;
        player.transform.position += dir * 0.01f;
    }

}
