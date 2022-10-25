using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SceneController;
using UnityEngine.UI;

public class TextChange : MonoBehaviour
{
    public string[] TextContent;
    public int TextIndex;
    public string TextNow;
    public string NextScene;
    public Text text;
    public int CharacterPreIndex;

    public GameObject Character;

    void start()
    {
        TextIndex = 0;
        TextUpdate();
    }

    

    private void TextUpdate()
    {
        TextNow = TextContent[TextIndex];
        text.text = TextNow;
        TextEffects te = text.GetComponent<TextEffects>();
        te.ReSet();
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
            if (TextIndex == CharacterPreIndex)
            {
                Transparency Chara = Character.GetComponent<Transparency>();
                Chara.SetPresent();
            }
        }
        else
        {
            ToNextScene();
        }
    }

    private void ToNextScene()
    {
        SceneController.SceneController.LoadTargetScene(NextScene);
    }
}
