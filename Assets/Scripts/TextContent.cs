using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentSave : MonoBehaviour
{
    public string[] TextContent;
    public int TextIndex;
    public string TextNow;
    public Text text;




    private void TextRePresent()
    {
        TextNow = TextContent[TextIndex];
        text.text = TextNow;
    }

    public void TextToIndex(int i)
    {
        TextIndex = i;
        TextRePresent();
    }

   /* public void TextAfter()
    {
        if (TextIndex < TextContent.Length - 1)
        {
            TextIndex++;
            TextUpdate();
        }
        else
        {
            TextIndex = 0;
        }

    }*/

    
}
