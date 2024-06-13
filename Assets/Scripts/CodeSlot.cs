using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CodeSlot : MonoBehaviour
{
    public int SlotID;
    public XRSocketInteractor socket;
    public AudioSource Audio;
    // Start is called before the first frame update
    void Start()
    {
        //socket = GetComponent<XRSocketInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckID()
    {
        if(SoundManager.Instance.SoundSFX)
            Audio.Play();
        IXRSelectInteractable objName = socket.GetOldestInteractableSelected();
        BlockCode b = objName.transform.gameObject.GetComponent<BlockCode>();
        if(b.GetBlockID() == this.SlotID)
        {
            Debug.Log("Correct");
            GamePlayManager.Instance.HandleCorrectSlot(this.SlotID);
        }
        else
        {
            Debug.Log("Incorrect");
            GamePlayManager.Instance.HanldeInCorrectSlot(this.SlotID);
        }   
        //Debug.Log(this.SlotID);
    }
    public void ExitBlock()
    {
        GamePlayManager.Instance.HanldeInCorrectSlot(this.SlotID);
    }
    public void PlayerGetCode()
    {
        GamePlayManager.Instance.HanldeInCorrectSlot(this.SlotID);
    }
}
