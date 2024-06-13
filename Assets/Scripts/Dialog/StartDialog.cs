using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartDialog : DialogBase
{
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HandleClickStartGame()
    {
        SoundManager.Instance.SoundClickButtonUI();
        UIManager.Instance.ClickButtonStart();
    }
    public void HandleClickSetting()
    {
        SoundManager.Instance.SoundClickButtonUI();
        UIManager.Instance.ClickButtonSetting();
    }
    public void HandleClickLevels()
    {
        UIManager.Instance.ClickButtonListLevel();
    }
}
