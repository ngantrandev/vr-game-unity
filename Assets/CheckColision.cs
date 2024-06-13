using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "MainCamera")
        {
            if ((GameManager.Instance._CurrentLevel + 1) <2)
            { 
                GameManager.Instance.GetConfigLevel(GameManager.Instance._CurrentLevel + 1);
            }
            else
            {
                GameManager.Instance.OnHomeScene();
            }
            //GameManager.Instance.StartGameLevel_2();
        }

    }
}
