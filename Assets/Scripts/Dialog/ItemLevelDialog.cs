using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ItemLevelDialog : MonoBehaviour
{
    public int level;
    public TextMeshProUGUI Text;
    public GameObject lockitem;
    public GameObject Bossitem;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void settext(int level_)
    {
        level = level_;
        Text.text = "Level" + level.ToString();
        if (level <= GameManager.Instance.GetResourceFile<LevelConfigs>("LevelConfigs").GetConfig().Count)
        {
            lockitem.SetActive(false);
            if (GameManager.Instance.GetResourceFile<LevelConfigs>("LevelConfigs").GetConfig()[level-1].Quiz)
            {
                Bossitem.SetActive(true);
            }
            else
            {
                Bossitem.SetActive(false);
            }
        }
        else
        {
            lockitem.SetActive(true);
            Bossitem.SetActive(false);
        }
    }
    public void clickbtn()
    {
        if (level <= GameManager.Instance.GetResourceFile<LevelConfigs>("LevelConfigs").GetConfig().Count)
        {
            SoundManager.Instance.SoundClickButtonUI();
            GameManager.Instance.GetConfigLevel(level - 1);
        }
    }
}
