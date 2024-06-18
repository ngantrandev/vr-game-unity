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
    public int id;
    public bool ison;
    // Start is called before the first frame update
    void Start()
    {
        Toggle = this.GetComponent<Toggle>();
        labelItem.text = Content;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void clickitem()
    {
        if (this.id == UIManager.Instance.GetComponent<QuizDialog>().idQuiz)
        {
            //UIManager.Instance.GetComponent<QuizDialog>().GetQuizAndSetup();
            //Trả lời đúng
        }
        else
        {
            //Trả lời sai
        }
    }
}
