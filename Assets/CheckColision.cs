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
            //GameManager.Instance.StartGameLevel_2();
            GameManager.Instance.OnHomeScene();
        }

    }
}
