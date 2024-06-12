using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockCode : MonoBehaviour
{
    private int _BlockID;
    private string Content;
    public TextMeshPro _Text;
    // Start is called before the first frame update
    void Start()
    {
        _Text.text = Content!=null?Content:"Null";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetBlockID()
    {
        return this._BlockID;
    }
    public int SetBlockID(int value)
    {
        this._BlockID = value;
        return this._BlockID;
    }
    public string GetContent()
    {

       return this.Content;
    }
    public string SetContent(string value)
    {
        this.Content = value;
        return this.Content;
    }
}
