using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockCode : MonoBehaviour
{
    private int _BlockID;
    private string Content;
    public GameObject Star;
    public TextMeshPro _Text;
    public bool staroff = false;
    public GameObject player;
    private int speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        player = Camera.main.gameObject;
        _Text.text = Content!=null?Content:"Null";
    }
    public void handlestaroff()
    {
        Debug.Log("Tat ne");
        staroff = true;
        Star.SetActive(false);
    }
    public void handlestaron()
    {
        staroff= false;
        Star.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (!staroff)
        {
            Vector3 direction = player.transform.position - Star.transform.position;
            direction.y = 0; // Không thay đổi trục y của hướng

            // Quaternion hướng về phía người chơi
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            // Chỉ lấy phần góc xoay Y
            Quaternion yRotation = Quaternion.Euler(0, lookRotation.eulerAngles.y, 0);

            // Nội suy xoay từ hướng hiện tại sang hướng mới chỉ trên trục Y
            Star.transform.rotation = Quaternion.Slerp(Star.transform.rotation, yRotation, speed * Time.deltaTime);
        }
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
