using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionDialog : DialogBase
{
    public TextMeshProUGUI Content;
    // Start is called before the first frame update
    void Start()
    {
        base.checkAudio();
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

}
