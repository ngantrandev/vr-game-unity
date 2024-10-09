using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBase : MonoBehaviour
{
    public Image iconSfx;
    public Image iconMusic;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    virtual public void Show()
    {
        if(UIManager.Instance._CurrentDialog!=null)
            UIManager.Instance._CurrentDialog.close();
        UIManager.Instance._CurrentDialog =  Instantiate(this, UIManager.Instance.DialogTransform);
    }
    public void close()
    {
        Destroy(UIManager.Instance._CurrentDialog.gameObject);
    }
    public void HandleClickMusic()
    {
        bool statusMusic = SoundManager.Instance.ChangeStatusMusic();
        if (statusMusic)
        {
            iconMusic.sprite = UIManager.Instance.sprites[3];
        }
        else
        {
            iconMusic.sprite = UIManager.Instance.sprites[2];
        }
    }
    public void HandleClickSfx()
    {
        bool StatusSfx = SoundManager.Instance.ChangeStatusSoundSFX();
        if (StatusSfx)
        {
            iconSfx.sprite = UIManager.Instance.sprites[1];
        }
        else
        {
            iconSfx.sprite = UIManager.Instance.sprites[0];
        }
    }
    public void HandleClickLeaveLevel()
    {
        SoundManager.Instance.SoundClickButtonUI();
        GameManager.Instance.OnHomeScene();
    }
    public void checkAudio()
    {
        if (SoundManager.Instance.SoundSFX)
        {
            iconSfx.sprite = UIManager.Instance.sprites[1];
        }
        else
        {
            iconSfx.sprite = UIManager.Instance.sprites[0];
        }
        if (SoundManager.Instance.SoundMusic)
        {
            iconMusic.sprite = UIManager.Instance.sprites[3];
        }
        else
        {
            iconMusic.sprite = UIManager.Instance.sprites[2];
        }
        
    }
}
