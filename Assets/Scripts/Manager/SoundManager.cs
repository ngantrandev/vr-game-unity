using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    public bool SoundSFX = true;
    public bool SoundMusic = true;
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
        return SoundSFX;
    }
    public bool ChangeStatusMusic() { 
        SoundMusic = !SoundMusic;
        return SoundMusic;
    }
}
