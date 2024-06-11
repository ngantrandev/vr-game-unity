using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private bool GameStart = false;
    // Start is called before the first frame update
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
}
