using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsDialog : DialogBase
{
    public GameObject Container;
    public GameObject Item;
    public List<int> LevelIDs; 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Show()
    {
        base.Show();
        foreach (int levelID in LevelIDs) {
            GameObject ItemLevel = Instantiate(Item, UIManager.Instance._CurrentDialog.GetComponent<LevelsDialog>().Container.transform);
            ItemLevel.GetComponent<ItemLevelDialog>().settext(levelID);
        }
    }
    public void HandleClickBackDialog()
    {
        SoundManager.Instance.SoundClickButtonUI();
        UIManager.Instance.ShowDialogStartGame();
    }
}
