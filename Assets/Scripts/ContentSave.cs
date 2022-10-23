using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextContentSave : MonoBehaviour
{
    public string[] TextContent;
    public int TextIndex;
    public string TextNow;
    public Text text;

    void start()
    {
        TextIndex = 0;
        TextUpdate();
    }



    private void TextUpdate()
    {
        TextNow = TextContent[TextIndex];
        text.text = TextNow;
    }

    public void TextBefore()
    {
        if (TextIndex > 0)
        {
            TextIndex--;
        }
        TextUpdate();
    }

    public void TextAfter()
    {
        if (TextIndex < TextContent.Length - 1)
        {
            TextIndex++;
            TextUpdate();
        }
        
    }

    
}
