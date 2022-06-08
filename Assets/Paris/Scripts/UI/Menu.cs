using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public void Awake()
    {
        Time.timeScale = 0;
        AudioManager.Instance.Play(Audio.BGM_MENU);
    }

    public void Play()
    {
        Time.timeScale = 1;
        MenuManager.Instance.Menu.SetActive(false);
    }

    public void Settings(bool open)
    {
        if(open)
        {
            MenuManager.Instance.Title.text = "Settings";
        }
        else
        {
            MenuManager.Instance.Title.text = "TRAIN GAME";
        }
    }

    public void ButtonSound(int type)
    {
        switch(type)
        {
            case 0: // Hover
                AudioManager.Instance.Play(Audio.SFX_HOVER);
                break;
            case 1: // Click
                AudioManager.Instance.Play(Audio.SFX_GUNSHOT);
                break;
        }
        
    }

}
