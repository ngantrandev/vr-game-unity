using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    public Transform DialogTransform;
    public DialogBase StartDialog;
    public DialogBase SettingDialog;
    public DialogBase LevelsDialog;
    public QuestionDialog QuestionDialog;
    public DialogBase _CurrentDialog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickButtonStart()
    {
        GameManager.Instance.OnJonGame(GameManager.Instance._CurrentPlayinglevel);
    }
    public void ClickButtonSetting()
    {
        ShowDialogSetting();
    }
    public void ClickButtonListLevel()
    {
        ShowDialogLevels();
    }
    public void ShowDialogStartGame()
    {
        StartDialog.Show();
    }
    public void ShowDialogSetting()
    {
        SettingDialog.Show();
    }
    public void ShowDialogQuestion()
    {
        QuestionDialog.Show();       
    }
    public void ShowDialogLevels()
    {
        LevelsDialog.Show();
    }
}
