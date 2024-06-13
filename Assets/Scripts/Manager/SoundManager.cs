using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    public bool SoundSFX = true;
    public bool SoundMusic = true;
    public SoundSceneGame SoundScene;
    public AudioClip SoundClickButton;
    public AudioSource SFXUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool ChangeStatusSoundSFX()
    {
        SoundSFX = !SoundSFX;
        SoundScene.CheckStatusSFX();
        return SoundSFX;
    }
    public bool ChangeStatusMusic() { 
        SoundMusic = !SoundMusic;
        SoundScene.CheckStatusMusic();
        return SoundMusic;
    }
    public void SoundClickButtonUI()
    {
        if (SoundSFX)
        {
            SFXUI.clip = SoundClickButton;
            SFXUI.Play();
        }
    }
}
