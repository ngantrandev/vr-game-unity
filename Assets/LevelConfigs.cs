﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Game/LevelConfigs",fileName ="LevelConfigs")]
public class LevelConfigs : ScriptableObject
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
    public List<LevelConfig> _Level;
    public List<LevelConfig> GetConfig()
    {
        return _Level;
    }
}
[System.Serializable]
public class LevelConfig
{
    public int _LevelID;
    public Vector3 GatePosition;
    public bool Quiz;
    [Header("Câu hỏi trong Level")]
    [TextAreaAttribute]
    public string QuestionContent;
    [Header("Vị trí của codeSlot")]
    public List<SlotCodeAttribute> SlotCodes;
    [Header("Vị trí của BlockCode")]
    public List<BlockCodeAttribute> BlockCodes;
}
[System.Serializable]
public class SlotCodeAttribute
{
    public int _BlockID;
    public Vector3 Position;
}
[System.Serializable]
public class BlockCodeAttribute
{
    public int _BlockID;
    public Vector3[] Position;
    [TextAreaAttribute]
    public string Content;
}
