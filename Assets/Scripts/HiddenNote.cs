using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenNote : MonoBehaviour
{
    public bool present = false;
    public bool hidden = false;
    public float timer;
    public float waittime = 0;
    //Ω•±‰ ±≥§
    public float time = 1f;

    public void SetDisplay()
    {
        present = true;
        /*CanvasGroup cg = GetComponent<CanvasGroup>();
        cg.alpha = 1;
        GetComponent<Button>().enabled = true;
        Button button = GetComponent<Button>();
        button.interactable = true;*/
    }

    public void SetHidden()
    {
        CanvasGroup cg = GetComponent<CanvasGroup>();
        if(cg.alpha==1)
        hidden = true;
    }

    void Update()
    {

        if (present)
        {
            CanvasGroup cg = GetComponent<CanvasGroup>();
            /*cg.alpha = 1;*/
            

            timer += Time.deltaTime;
            if (timer > waittime)
            {
                cg.alpha = 1 - ((time - (timer - waittime)) / time);
            }
            if (timer > waittime + time)
            {
                present = false;
                timer = 0;
            }


        }

        if (hidden)
        {
            CanvasGroup cg = GetComponent<CanvasGroup>();
            /*cg.alpha = 1;*/
            

            timer += Time.deltaTime;
            if (timer > waittime)
            {
                cg.alpha = ((time - (timer - waittime)) / time);
            }
            if (timer > waittime + time)
            {
                hidden = false;
                timer = 0;
            }


        }
    }
}
