using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GamePlayManager : MonoSingleton<GamePlayManager>
{
    public LevelConfig _LevelConfig;
    public GameObject CodeSlot;
    public GameObject CodeBlock;
    public bool[] CorrectSlot;
    // Start is called before the first frame update
    void Start()
    {
        _LevelConfig = GameManager.Instance._CurrentPlayinglevel;
        CorrectSlot = new bool[_LevelConfig.SlotCodes.Count];    
        foreach(SlotCodeAttribute slot in _LevelConfig.SlotCodes)
            {
                GameObject _Codeslot =  Instantiate(CodeSlot,slot.Position,Quaternion.identity);
            Debug.Log(_Codeslot.transform.GetChild(0).name);
                _Codeslot.transform.GetChild(0).GetComponent<CodeSlot>().SlotID = slot._BlockID;
            }
            foreach(BlockCodeAttribute block in _LevelConfig.BlockCodes)
            {
                Vector3 _Position = block.Position[this.RandomInrange(0,block.Position.Length-1)];
            Debug.Log(_Position);
                GameObject _CodeBlock = Instantiate(CodeBlock,_Position, Quaternion.identity);
                _CodeBlock.GetComponent<BlockCode>().SetBlockID(block._BlockID);
                _CodeBlock.GetComponent<BlockCode>().SetContent(block.Content);
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int RandomInrange(int a, int b)
    {
        int value = Random.Range(a, b);
        return value;
    }
    public void HandleCorrectSlot(int slotid)
    {
        int i = 0;
        this.CorrectSlot[slotid] = true;
        foreach (bool status in this.CorrectSlot) {
            i++;
            if (status == false || status == null) {
                return;
            }
        }
        if (i == this.CorrectSlot.Length)
        {
            Debug.Log("Kết thúc màn chơi");
        }
    }
    public void HanldeInCorrectSlot(int slotid)
    {
        this.CorrectSlot[slotid] = false;
    }
}
