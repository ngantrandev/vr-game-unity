using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    virtual public void Show()
    {
        if(UIManager.Instance._CurrentDialog!=null)
            UIManager.Instance._CurrentDialog.close();
        UIManager.Instance._CurrentDialog =  Instantiate(this, UIManager.Instance.DialogTransform);
    }
    public void close()
    {
        Destroy(UIManager.Instance._CurrentDialog.gameObject);
    }
}
