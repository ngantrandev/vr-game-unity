using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UISceneGame : MonoSingleton<UISceneGame>
{
    public Button BtnStartGame;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HandleButtonStartGame()
    {
        UIManager.Instance.ClickButtonStart();
    }
    public void HandleButtonSettingGame()
    {
        Debug.Log("Setting");
    }
}
