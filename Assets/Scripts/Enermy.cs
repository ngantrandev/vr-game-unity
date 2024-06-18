using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    public Animator animator_;
    public ActionName Actionnames;
    public Transform Player;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        animator_ = GetComponent<Animator>();
        animator_.Play(Actionnames.Idle.name);
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Player.position - transform.position;
        direction.y = 0; // Không thay đổi trục y của hướng

        // Quaternion hướng về phía người chơi
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        // Chỉ lấy phần góc xoay Y
        Quaternion yRotation = Quaternion.Euler(0, lookRotation.eulerAngles.y, 0);

        // Nội suy xoay từ hướng hiện tại sang hướng mới chỉ trên trục Y
        transform.rotation = Quaternion.Slerp(transform.rotation, yRotation, speed * Time.deltaTime);
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

