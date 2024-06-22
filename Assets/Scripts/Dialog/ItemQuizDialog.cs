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
    public Animator _animation;
    public string AnimationCorrect = "Correct";
    public string AnimationInCorrect = "InCorrect";
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
        if (this.Toggle.group.AnyTogglesOn())
        {
            this.Toggle.interactable = false;
        }
        else
        {
            this.Toggle.interactable= true;
        }
    }
    public void clickitem()
    {
        if (this.CorrectAnswer && Toggle.isOn)
           {
                //UIManager.Instance.GetComponent<QuizDialog>().GetQuizAndSetup();
                //Trả lời đúng
                //Debug.Log("Đúng");
                _animation.Play(AnimationCorrect);
            }
            else
            {
                if (Toggle.isOn)
                {
                    //Debug.Log("Sai");
                    _animation.Play(AnimationInCorrect);
                }
                //Trả lời sai
            }
    }
    public void IsCorrect_AnimationRun()
    {
        GameManager.Instance.CorrectAnswer();
        Toggle.isOn = false;
    }
    public void IsInCorrect_AnimationRun()
    {
        GameManager.Instance.IncorrectAnswser();
        Toggle.isOn = false;
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
