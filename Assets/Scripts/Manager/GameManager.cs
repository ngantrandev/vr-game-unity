﻿using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
//using UnityEngine.InputSystem.iOS;

public class GameManager : MonoSingleton<GameManager>
{
    private bool GameStart = false;
    public int NumberScene_PlayGame_1 = 2;
    public int NumberScene_PlayGame_2 = 3;
    public int NumberScene_PlayGame_3 = 4;
    public int NumberScene_PlayGame_4 = 5;
    public int NumberScene_Home = 1;
    public int _CurrentLevel;
    public LevelConfig _CurrentPlayinglevel;
    public QuizConfig _CurrentQuizConfig;
    public List<QuizQuestion> _QuizList;
    public int CountQuizEndgame = 10;
    public int CountIncorrectQuiz = 0;
    public int CountCorrectQuiz = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        _CurrentLevel = 0;
        _CurrentPlayinglevel = GameManager.Instance.GetResourceFile<LevelConfigs>("LevelConfigs").GetConfig()[_CurrentLevel];
    }
    void Start()
    {
        OnHomeScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool GetGameStart()
    {
       return GameStart;
    }
    public bool SetGameStart(bool value)
    {
        GameStart = value;
        return GameStart;
    }
    /// <summary>
    /// Load một file từ folder Resource
    /// </summary>
    /// <typeparam name="T">Kiểu dữ liệu hoặc 1 component</typeparam>
    /// <param name="path">Đường dẫn file, bỏ đuôi file và phần /Resource</param>
    /// <returns></returns>
    public T GetResourceFile<T>(string path) where T : Object
    {
        return Resources.Load<T>(path) as T;
    }
    public void GetConfigLevel(int level)
    {
        _CurrentLevel = level;
        _CurrentPlayinglevel = GameManager.Instance.GetResourceFile<LevelConfigs>("LevelConfigs").GetConfig()[_CurrentLevel];
        if (_CurrentPlayinglevel.Quiz) {
            _CurrentQuizConfig = GameManager.Instance.GetResourceFile<QuizConfigs>("QuizConfigs").GetConfig()[0];
        }
        if( _CurrentLevel == 0)
        {
            this.OnJonGame(_CurrentPlayinglevel);
        }
        if (_CurrentLevel == 1) {
            this.StartGameLevel_2(_CurrentPlayinglevel);
        }
        if (_CurrentLevel == 2) { 
            this.StartGameLevel_3(_CurrentPlayinglevel);
        }
        if(_CurrentLevel == 3) {
            this.StartGameLevel_4((_CurrentPlayinglevel));
        }
    }
    // Mở Level Màn chơi
    public void OnJonGame(LevelConfig config)
    {
        this._CurrentPlayinglevel = config;
        switch(_CurrentLevel)
        {
            case 0:
                UnityEngine.SceneManagement.SceneManager.LoadScene(NumberScene_PlayGame_1);
                break;
            case 1:
                UnityEngine.SceneManagement.SceneManager.LoadScene(NumberScene_PlayGame_2);
                break;
            case 2:
                UnityEngine.SceneManagement.SceneManager.LoadScene(NumberScene_PlayGame_3);
                break;
            case 3:
                StartGameLevel_4(_CurrentPlayinglevel);
                break;
        }

    }
    public void StartGameLevel_2(LevelConfig config)
    {
        this._CurrentPlayinglevel = config;
        UnityEngine.SceneManagement.SceneManager.LoadScene(NumberScene_PlayGame_2);
    }
    public void StartGameLevel_3(LevelConfig config) {
        this._CurrentPlayinglevel = config;
        UnityEngine.SceneManagement.SceneManager.LoadScene(NumberScene_PlayGame_3);
    }
    public void StartGameLevel_4(LevelConfig config)
    {
        this._CurrentPlayinglevel = config;
        UnityEngine.SceneManagement.SceneManager.LoadScene(NumberScene_PlayGame_4);
        CountIncorrectQuiz = 0;
        CountCorrectQuiz = 0;
    }
    public void OnHomeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(NumberScene_Home);
    }
    public void ReadFileExam()
    {
        _QuizList = QuizReader.ReadQuizFromFile();
    }
    public (int,QuizQuestion) RandomQuizQuestion()
    {
        int idquestion = Random.Range(0, _QuizList.Count);
        QuizQuestion Q = _QuizList[idquestion];
        return (idquestion,Q);
    }
    public void CorrectAnswer()
    {
        GamePlayManager.Instance.HandleQuizCorrectAnswer();
        UIManager.Instance._CurrentDialog.GetComponent<QuizDialog>().GetQuizAndSetup();
        CountCorrectQuiz++;
        if (CountCorrectQuiz == CountQuizEndgame)
        {
            UIManager.Instance._CurrentDialog.close();
            GamePlayManager.Instance.HandleWinGameQuiz();
        }

    }
    public void IncorrectAnswser()
    {
        GamePlayManager.Instance.HandleQuizInCorrectAnswer();
        CountIncorrectQuiz+=1;
        //UIManager.Instance._CurrentDialog.GetComponent<QuizDialog>().GetQuizAndSetup();
        //if (CountIncorrectQuiz >= CountQuizEndgame/2)
        //{
        //    OnHomeScene();
        //}
    }
}
