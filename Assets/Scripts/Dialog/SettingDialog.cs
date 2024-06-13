using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingDialog : DialogBase
{
    public Sprite[] sprites;
    public Image iconMusic;
    public Image iconSfx;
    // Start is called before the first frame update
    void Start()
    {
        if (SoundManager.Instance.SoundMusic)
        {
            iconMusic.sprite = sprites[0];
        }
        else
        {
            iconMusic.sprite = sprites[1];
        }
        if (SoundManager.Instance.SoundSFX)
        {
            iconSfx.sprite = sprites[0];
        }
        else
        {
            iconSfx.sprite = sprites[1];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HandleClickMusic()
    {
        bool statusMusic = SoundManager.Instance.ChangeStatusMusic();
        if (statusMusic)
        {
            iconMusic.sprite= sprites[0];
        }
        else
        {
            iconMusic.sprite = sprites[1];
        }
    }
    public void HandleClickSfx()
    {
        bool StatusSfx = SoundManager.Instance.ChangeStatusSoundSFX();
        if (StatusSfx)
        {
            iconSfx.sprite = sprites[0];
        }
        else
        {
            iconSfx.sprite = sprites[1];
        }
    }
    public void HandleClickBackDialog()
    {
        SoundManager.Instance.SoundClickButtonUI();
        UIManager.Instance.ShowDialogStartGame();
    }
}
