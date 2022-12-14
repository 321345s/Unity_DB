using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransparencyReverse : MonoBehaviour
{
    //等待时间
    public float waittime = 0;
    //渐变时长
    public float time = 1f;
    //定时器
    public float timer;
    //透明度 范围是0-1
    float alpha = 0f;

    float startAlpha = 1f;
    //启用状态
    public bool workingstatus = true;

    public Transform ts;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, startAlpha);
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
                alpha = ((time - (timer - waittime)) / time);
                gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, alpha);
            }
            if (timer > waittime + time)
            {
                workingstatus = false;
                ts.SetSiblingIndex(0);
            }
        }
    }

}
