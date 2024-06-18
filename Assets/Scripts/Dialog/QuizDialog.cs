using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class QuizDialog : DialogBase
{
    public string Question;
    public GameObject Container;
    public GameObject ItemQuiz_Prefab;
    public int idQuiz;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetQuizAndSetup()
    {
        QuizConfig QuizConfig = GameManager.Instance._CurrentQuizConfig;
        this.Question = QuizConfig.QuizTitle;
        this.idQuiz = QuizConfig._IDQuiz;
        foreach(QuizItem item in QuizConfig.QuizItems)
        {
            GameObject  C = Instantiate(ItemQuiz_Prefab, UIManager.Instance.GetComponent<QuizDialog>().Container.transform);
            C.GetComponent<Toggle>().group = UIManager.Instance.GetComponent<QuizDialog>().Container.GetComponent<ToggleGroup>();
        }
    }
    public override void Show()
    {
        base.Show();
        GetQuizAndSetup();
    }
}
