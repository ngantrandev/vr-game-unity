using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private bool GameStart = false;
    public int NumberScene_PlayGame_1 = 1;
    public int NumberScene_PlayGame_2 = 2;
    public int NumberScene_PlayGame_3 = 3;
    public int NumberScene_PlayGame_4 = 4;
    public int NumberScene_Home = 0;
    public int _CurrentLevel;
    public LevelConfig _CurrentPlayinglevel;
    public QuizConfig _CurrentQuizConfig;
    public List<QuizQuestion> _QuizList;
    // Start is called before the first frame update
    private void Awake()
    {
        _CurrentLevel = 3;
        _CurrentPlayinglevel = GameManager.Instance.GetResourceFile<LevelConfigs>("LevelConfigs").GetConfig()[_CurrentLevel];
    }
    void Start()
    {
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
        UnityEngine.SceneManagement.SceneManager.LoadScene(NumberScene_PlayGame_1);
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

    }
    public void IncorrectAnswser()
    {
        GamePlayManager.Instance.HandleQuizInCorrectAnswer();
        //UIManager.Instance._CurrentDialog.GetComponent<QuizDialog>().GetQuizAndSetup();
    }
}
