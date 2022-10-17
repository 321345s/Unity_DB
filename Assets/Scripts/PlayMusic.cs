using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    //�����ļ�
    public AudioSource music;

    /// <summary>���ŷ�����</summary>
    public void playMusic()
    {
        
            music.Play();
        
    }

    public void click()
    {
        print("Click!");
        if (music != null && !music.isPlaying)
        {
            music.Play();
        }
        else
        {
            music.Stop();
        }
    }

    /// <summary>�ر����ֲ���</summary>
    public void stopMusic()
    {
        if (music != null && music.isPlaying)
        {
            music.Stop();
        }
    }

    /// <summary>��ͣ���ֲ���</summary>
    public void pauseMusic()
    {
        if (music != null && music.isPlaying)
        {
            music.Pause();
        }
    }

    /// <summary>
    /// ���ò�������
    /// </summary>
    /// <param name="volume"></param>
    private void setMusicVolume(float volume)
    {
        if (music != null && !music.isPlaying)
        {
            music.volume = volume;
        }
    }

    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            print("�����������£�");
            playMusic();
        }
        if (Input.GetMouseButtonDown(1))
        {
            print("����Ҽ������£�");
            stopMusic();
        }*/
    }

}
