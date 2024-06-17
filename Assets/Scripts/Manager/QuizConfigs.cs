using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Game/QuizConfig",fileName = "QuizConfigs")]
public class QuizConfigs : ScriptableObject
{
    #region SingleTon
    private static LevelConfigs _isntance;
    public static LevelConfigs Instance
    {
        get
        {
            if (_isntance == null)
            {
                _isntance = GameManager.Instance.GetResourceFile<LevelConfigs>("Configs/LevelConfigs");
                
            }
            return _isntance;
        }
    }
    #endregion
    public List<QuizConfig> QuizList;
    public List<QuizConfig> GetConfig()
    {
        return QuizList;
    }
}
[System.Serializable]
public class QuizConfig
{
    public int _IDQuiz;
    public GameObject TransformPositionInMap;
    public  Vector3 GatePosition;
    [Header("Câu hỏi")]
    [TextAreaAttribute]
    public string QuizTitle;
    [Header("Danh sách câu trả lời")]
    public List<QuizItem> QuizItems;
}
[System.Serializable]
public class QuizItem
{
    //public int _ID;
    public bool _Status = false;
    [TextAreaAttribute]
    public string _Content;
}
