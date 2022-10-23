using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenButton : MonoBehaviour
{


    public void SetDisplay()
    {
        CanvasGroup cg = GetComponent<CanvasGroup>();
        cg.alpha = 1;
        /*GetComponent<Button>().enabled = true;*/
        Button button = GetComponent<Button>();
        button.interactable = true;
    }

    public void SetHidden()
    {

    }

    void start()
    {
        /*GetComponent<Button>().enabled = false;*/
        /*Button button = GetComponent<Button>();
        button.enabled = false;*/
    }

    public void ClickButton()
    {
        print("Button Clicked!");
    }
}
