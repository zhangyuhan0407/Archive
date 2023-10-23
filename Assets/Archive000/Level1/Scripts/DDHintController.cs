using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DDHintController : MonoBehaviour
{
    //����ģʽ
    public static DDHintController Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<string> hints;
    public Image hintImage;

    // Start is called before the first frame update
    void Start()
    {
        HideHint();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ShowHint(string imageName)
    {
        hintImage.gameObject.SetActive(true);       //��ʾ��ͼƬ
        hintImage.sprite = Resources.Load<Sprite>("TXT/" + imageName);
        Invoke("HideHint", 3.0f);
    }


    public void HideHint()
    {
        hintImage.gameObject.SetActive(false);
    }

}
