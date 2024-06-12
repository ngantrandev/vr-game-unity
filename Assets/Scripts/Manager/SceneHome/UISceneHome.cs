using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UISceneGame : MonoSingleton<UISceneGame>
{
    public Transform DialogTransform;
    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.DialogTransform = DialogTransform;
        UIManager.Instance.ShowDialogStartGame();
        //StartDialog.Show();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
