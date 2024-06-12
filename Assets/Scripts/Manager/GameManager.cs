using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private bool GameStart = false;
    public int NumberScene_PlayGame_1 = 1;
    public int NumberScene_PlayGame_2 = 2;
    public int NumberScene_Home = 0;
    public int _CurrentLevel;
    public LevelConfig _CurrentPlayinglevel;
    // Start is called before the first frame update
    private void Awake()
    {
        _CurrentLevel = 0;
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
        UnityEngine.SceneManagement.SceneManager.LoadScene(NumberScene_PlayGame_2);
    }
    public void OnHomeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(NumberScene_Home);
    }
}
