using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionDialog : DialogBase
{
    public TextMeshProUGUI Content;
    public Sprite[] sprites;
    public Image iconSfx;
    public Image iconMusic;
    // Start is called before the first frame update
    void Start()
    {
        checkAudio();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Show()
    {
        Content.text = GameManager.Instance._CurrentPlayinglevel.QuestionContent;
        base.Show();
    }
    public void HandleClickMusic()
    {
        bool statusMusic = SoundManager.Instance.ChangeStatusMusic();
        if (statusMusic)
        {
            iconMusic.sprite = sprites[3];
        }
        else
        {
            iconMusic.sprite = sprites[2];
        }
    }
    public void HandleClickSfx()
    {
        bool StatusSfx = SoundManager.Instance.ChangeStatusSoundSFX();
        if (StatusSfx)
        {
            iconSfx.sprite = sprites[1];
        }
        else
        {
            iconSfx.sprite = sprites[0];
        }
    }
    void checkAudio()
    {
        if (SoundManager.Instance.SoundSFX)
        {
            iconSfx.sprite = sprites[1];
        }
        else
        {
            iconSfx.sprite = sprites[0];
        }
        if (SoundManager.Instance.SoundMusic)
        {
            iconMusic.sprite = sprites[3];
        }
        else
        {
            iconMusic.sprite = sprites[1];
        }
    }
}
