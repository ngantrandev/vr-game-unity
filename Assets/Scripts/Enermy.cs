using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    public Animator animator_;
    public ActionName Actionnames;
    // Start is called before the first frame update
    void Start()
    {
        animator_ = GetComponent<Animator>();
        animator_.Play(Actionnames.Idle.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }
}
[System.Serializable]
public class ActionName
{
    public AnimationClip Walking;
    public AnimationClip Idle;
    public AnimationClip Jump;
    public AnimationClip Hit;
    public AnimationClip Death;
}

