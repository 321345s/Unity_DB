using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    //音乐文件
    public AudioSource music;

    /// <summary>播放放音乐</summary>
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

    /// <summary>关闭音乐播放</summary>
    public void stopMusic()
    {
        if (music != null && music.isPlaying)
        {
            music.Stop();
        }
    }

    /// <summary>暂停音乐播放</summary>
    public void pauseMusic()
    {
        if (music != null && music.isPlaying)
        {
            music.Pause();
        }
    }

    /// <summary>
    /// 设置播放音量
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
            print("鼠标左键被按下！");
            playMusic();
        }
        if (Input.GetMouseButtonDown(1))
        {
            print("鼠标右键被按下！");
            stopMusic();
        }*/
    }

}
