using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemQuiz : MonoBehaviour
{
    public Text labelItem;
    public Toggle Toggle;
    public string Content;
    public bool CorrectAnswer = false;
    public bool ison;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Toggle>().group = this.gameObject.transform.parent.GetComponent<ToggleGroup>();
        Toggle = this.GetComponent<Toggle>();
        labelItem.text = Content;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void clickitem()
    {
        if (this.CorrectAnswer && Toggle.isOn)
        {
            //UIManager.Instance.GetComponent<QuizDialog>().GetQuizAndSetup();
            //Trả lời đúng
            Debug.Log("Đúng");
            GameManager.Instance.CorrectAnswer();
        }
        else
        {
            Debug.Log("Sai");
            GameManager.Instance.IncorrectAnswser();
            //Trả lời sai
        }
    }
    public void Setcontent(string text)
    {
        Content = text;
        labelItem.text = Content;
    }
    public void SetCorrectAnswer(bool Status)
    {
        CorrectAnswer = Status;
    }
}
