using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class LLBegining : MonoBehaviour
{

    public bool isStarting;
    public bool isEnd;
    public List<LLDialog> questions;
    public List<LLDialog> answers;
    public List<LLDialog> finals;

    public LLDialog m_Dialog;

    public UnityEvent AfterDialog;

    AudioSource m_AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();

        if(m_Dialog != null)
        {
            ShowDialog(m_Dialog);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarting == false) return;
        if (isEnd == true) return;


        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(m_Dialog != null)
            {
                HideDialog(m_Dialog);
                m_Dialog = m_Dialog.next;
                ShowDialog(m_Dialog, 1f);
            }

            if(m_Dialog == null)
            {
                AfterDialog?.Invoke();
            }
        }


    }




    void ShowDialog(LLDialog dialog, float delay = 0)
    {
        if (dialog == null) return;

        dialog.icon.DOFade(0, 0).OnComplete(() => {
            dialog.gameObject.SetActive(true);
        });

        dialog.icon.DOFade(1, 1).SetDelay(delay).OnComplete(() => {
            m_AudioSource.clip = dialog.clip;
            m_AudioSource.Play();
        });
    }

    void HideDialog(LLDialog dialog, float delay = 0)
    {
        if (dialog == null) return;

        dialog.icon.DOFade(1, 0).OnComplete(() => {
            m_AudioSource.Stop();
        });

        dialog.icon.DOFade(0, 1).OnComplete(() => {
            dialog.gameObject.SetActive(false);
        });
    }

}
