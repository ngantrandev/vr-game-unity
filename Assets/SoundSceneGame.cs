using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSceneGame : MonoSingleton<SoundSceneGame>
{
    public List<AudioSource> SoundsMusic;
    public List<AudioSource> SoundsSFX;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.SoundScene = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckStatusMusic()
    {
        SoundManager.Instance.SoundClickButtonUI();
        if (SoundManager.Instance.SoundMusic) {
            foreach (AudioSource source in SoundsMusic) { 
                source.mute = false;
            }
        }
        else
        {
            foreach (AudioSource source in SoundsMusic)
            {
                source.mute = true;
            }
        }
    }
    public void CheckStatusSFX() {
        SoundManager.Instance.SoundClickButtonUI();
        if (SoundManager.Instance.SoundSFX)
        {
            foreach(AudioSource source in SoundsSFX)
            {

            source.mute = false; 
            }
        }
        else
        {
            foreach( AudioSource source in SoundsSFX)
            {
                source.mute = true;
            }
        }
    }
}
