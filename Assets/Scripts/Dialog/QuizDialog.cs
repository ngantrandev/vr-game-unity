using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class QuizDialog : DialogBase
{
    public string Question;
    public TextMeshProUGUI QuestionText;
    public GameObject Container;
    public GameObject ItemQuiz_Prefab;
    public Image UIHealthPlayer;
    public int idQuiz;
    public float TimeoutSet = 10;
    float Timeout;
    public RectTransform Display;
    Vector2 CurrentSizeTime;
    Vector2 CurrentUIHealthPlayer;
    // Start is called before the first frame update
    void Start()
    {
        base.checkAudio();
        Timeout = TimeoutSet;
        CurrentSizeTime = Display.sizeDelta;
        UIHealthPlayer.rectTransform.sizeDelta = CurrentUIHealthPlayer;
        UpdateHP();
        GetQuizAndSetup();
    }

    // Update is called once per frame
    void Update()
    {
        Timeout -= Time.deltaTime;
        changetime(Timeout);
        if (Timeout < 1)
        {
           
            GameManager.Instance.IncorrectAnswser();
            GetQuizAndSetup();
        }
    }
    public void UpdateHP()
    {
        UIHealthPlayer.rectTransform.sizeDelta = new Vector2 (CurrentUIHealthPlayer.x,(GameManager.Instance.CountQuizEndgame/2-GameManager.Instance.CountIncorrectQuiz)*100/(GameManager.Instance.CountQuizEndgame/2));
    }
    void changetime(float currenttime)
    {
        currenttime += 1;
        float secound = Mathf.FloorToInt(currenttime);
        //Debug.Log(secound);
        Display.sizeDelta = new Vector2((currenttime * CurrentSizeTime.x / TimeoutSet), CurrentSizeTime.y);
    }
    public void GetQuizAndSetup()
    {
        //QuizConfig QuizConfig = GameManager.Instance._CurrentQuizConfig;
        //this.Question = QuizConfig.QuizTitle;
        //this.idQuiz = QuizConfig._IDQuiz;
        //foreach(QuizItem item in QuizConfig.QuizItems)
        //{
        //    GameObject  C = Instantiate(ItemQuiz_Prefab, UIManager.Instance.GetComponent<QuizDialog>().Container.transform);
        //    C.GetComponent<Toggle>().group = UIManager.Instance.GetComponent<QuizDialog>().Container.GetComponent<ToggleGroup>();
        //}
        ClearGameObject();
        QuizQuestion _quiz = GameManager.Instance.RandomQuizQuestion().Item2;
        idQuiz = GameManager.Instance.RandomQuizQuestion().Item1;
        Question = _quiz.Question;
        //Debug.Log(Question);
        QuestionText.text = Question;
        GameObject itemA = Instantiate(ItemQuiz_Prefab, UIManager.Instance._CurrentDialog.GetComponent<QuizDialog>().Container.transform);
        itemA.GetComponent<ItemQuiz>().Setcontent(_quiz.AnswerA);
        GameObject itemB = Instantiate(ItemQuiz_Prefab, UIManager.Instance._CurrentDialog.GetComponent<QuizDialog>().Container.transform);
        itemB.GetComponent<ItemQuiz>().Setcontent(_quiz.AnswerB);
        GameObject itemC = Instantiate(ItemQuiz_Prefab, UIManager.Instance._CurrentDialog.GetComponent<QuizDialog>().Container.transform);
        itemC.GetComponent<ItemQuiz>().Setcontent(_quiz.AnswerC);
        GameObject itemD = Instantiate(ItemQuiz_Prefab, UIManager.Instance._CurrentDialog.GetComponent<QuizDialog>().Container.transform);
        itemD.GetComponent<ItemQuiz>().Setcontent(_quiz.AnswerD);
        switch (_quiz.CorrectAnswer)
        {
            case "A":
                {
                    itemA.GetComponent<ItemQuiz>().SetCorrectAnswer(true);
                    break;
                }
            case "B":
                {
                    itemB.GetComponent<ItemQuiz>().SetCorrectAnswer(true);
                    break;
                }
            case "C":
                {
                    itemC.GetComponent<ItemQuiz>().SetCorrectAnswer(true);
                    break;
                }
            case "D":
                {
                    itemD.GetComponent<ItemQuiz>().SetCorrectAnswer(true);
                    break;
                }
        }
        Timeout = TimeoutSet;
    }
    public override void Show()
    {
        base.Show();
    }
    public void ClearGameObject()
    {
        foreach (Transform child in Container.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
