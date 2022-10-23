using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEffectColor : MonoBehaviour
{
    public Text targetText;

    public void SetColor()
    {
        //int begin,int end,string color
        /*string targetString = targetText.text;
        string tempString = targetString.Substr*/
        targetText.text = "<color=#0000ff>ίχίχίχ</color>";
    }
}
