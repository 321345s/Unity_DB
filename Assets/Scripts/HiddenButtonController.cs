using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenButtonController : MonoBehaviour
{
    public bool isPlaying = false;
    public bool isPlayingSolution = false;
    public AudioSource music;
    public AudioSource musicSolution;

    public GameObject HiddenButton0;
    public GameObject HiddenButton1;
    public GameObject HiddenButton2;
    public GameObject HiddenButtonNextScene;

    public void StartPlay()
    {
        isPlaying = true;
    }

    public void ButtonPresent()
    {
        HiddenButton HB0 = HiddenButton0.GetComponent<HiddenButton>();
        HB0.SetDisplay();
        HiddenButton HB1 = HiddenButton1.GetComponent<HiddenButton>();
        HB1.SetDisplay();
        HiddenButton HB2 = HiddenButton2.GetComponent<HiddenButton>();
        HB2.SetDisplay();

        /*isPlayingSolution = true;*/
    }

    public void ButtonHidden()
    {
        HiddenButton HB0 = HiddenButton0.GetComponent<HiddenButton>();
        HB0.SetHidden();
        HiddenButton HB1 = HiddenButton1.GetComponent<HiddenButton>();
        HB1.SetHidden();
        HiddenButton HB2 = HiddenButton2.GetComponent<HiddenButton>();
        HB2.SetHidden();

        /*isPlayingSolution = true;*/
    }

    public void SetSolutionPlaying()
    {
        isPlayingSolution = true;
    }

    void Update()
    {
        if (isPlaying)
        {
            if (!music.isPlaying)
            {
                ButtonPresent();
                isPlaying = false;
            }
            
        }
        if (isPlayingSolution)
        {
            /*Debug.Log("in if0");*/
            
            if (!musicSolution.isPlaying)
            {
                /*Debug.Log("in if1");*/
                HiddenButton HBN = HiddenButtonNextScene.GetComponent<HiddenButton>();
                HBN.SetDisplay();
                isPlayingSolution = false;
            }
            
        }
    }

}
