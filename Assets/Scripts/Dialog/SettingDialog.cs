using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingDialog : DialogBase
{
    // Start is called before the first frame update
    void Start()
    {
        if (SoundManager.Instance.SoundMusic)
        {
            iconMusic.sprite = UIManager.Instance.sprites[3];
        }
        else
        {
            iconMusic.sprite = UIManager.Instance.sprites[2];
        }
        if (SoundManager.Instance.SoundSFX)
        {
            iconSfx.sprite = UIManager.Instance.sprites[1];
        }
        else
        {
            iconSfx.sprite = UIManager.Instance.sprites[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HandleClickBackDialog()
    {
        SoundManager.Instance.SoundClickButtonUI();
        UIManager.Instance.ShowDialogStartGame();
    }
}
