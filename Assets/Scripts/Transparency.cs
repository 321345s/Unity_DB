using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transparency : MonoBehaviour
{
    //�ȴ�ʱ��
    public float waittime = 0;
    //����ʱ��
    public float time = 0.5f;
    //��ʱ��
    public float timer;
    //͸���� ��Χ��0-1
    float alpha = 0f;
    //����״̬
    public bool workingstatus = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, 0);
    }

    public void SetPresent()
    {
        workingstatus = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (workingstatus == true)
        {
            timer += Time.deltaTime;
            if (timer > waittime)
            {
                alpha = 1-((time - (timer - waittime)) / time);
                gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, alpha);
            }
            if (timer > waittime + time)
            {
                workingstatus = false;
            }
        }
    }

}
