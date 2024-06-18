using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enermy : MonoBehaviour
{
    public Animator animator_;
    public ActionName Actionnames;
    public SoundName Soundname_;
    public AudioSource Sound_;
    public GameObject Player;
    public AudioSource Terrain;
    public Image UIHealth_;
    public TextMeshProUGUI UITextHealth_;
    public float speed = 5f;
    Vector2 sizeHealth;
    // Start is called before the first frame update
    void Start()
    {
        GamePlayManager.Instance.Demon = this;
        animator_ = GetComponent<Animator>();
        animator_.Play(Actionnames.Idle.name);
        UIHealth_.rectTransform.sizeDelta = sizeHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Player.transform.position - transform.position;
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
        UpdateHP();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }
    public void PlayActionHit()
    {
        animator_.Play(Actionnames.Hit.name);
    }
    public void PlayActionAttack()
    {
        animator_.Play(Actionnames.Attack.name);
    }
    public void PlayActionDeath()
    {
        animator_.Play(Actionnames.Death.name);
    }
    public void GoToHome()
    {
        GameManager.Instance.OnHomeScene();
    }
    public void PlaySoundDeath()
    {
        Sound_.clip = Soundname_.Death;
        Sound_.Play();
    }
    public void SoundPlayHIT()
    {
        Sound_.clip = Soundname_.Hit;
        Sound_.Play();
    }
    public void PlaySoundAttack() {
        Sound_.clip = Soundname_.Attack;
        Sound_.Play();
    }
    public void AfterAttack() {
        UIManager.Instance._CurrentDialog.GetComponent<QuizDialog>().UpdateHP();
        if (GameManager.Instance.CountIncorrectQuiz>=GameManager.Instance.CountQuizEndgame/2)
        {
            GameManager.Instance.OnHomeScene();
        }
    }
    public void PlaySoundWalking()
    {
        Sound_.clip = Soundname_.Walking;
        Sound_.Play();
    }
    public void PlaySoundIdle()
    {
        Sound_.clip = Soundname_.Idle;
        Sound_.Play();
    }
    public void PlayEffectAttack()
    {
        Terrain.Play();
        EffectHitPlayer();
    }
    public void EffectHitPlayer()
    {
        Player.GetComponent<Player>().PlayerHIT();
    }
    public void UpdateHP()
    {
        UIHealth_.rectTransform.sizeDelta = new Vector2((GameManager.Instance.CountQuizEndgame - GameManager.Instance.CountCorrectQuiz) * 100 / GameManager.Instance.CountQuizEndgame, sizeHealth.y);
        UITextHealth_.text = (GameManager.Instance.CountQuizEndgame - GameManager.Instance.CountCorrectQuiz).ToString()+" / " + GameManager.Instance.CountQuizEndgame.ToString() + "HP";
    } 
}
[System.Serializable]
public class ActionName
{
    public AnimationClip Walking;
    public AnimationClip Idle;
    public AnimationClip Jump;
    public AnimationClip Attack;
    public AnimationClip Hit;
    public AnimationClip Death;
}
[System.Serializable]
public class SoundName
{
    public AudioClip Walking;
    public AudioClip Idle;
    public AudioClip Jump;
    public AudioClip Attack;
    public AudioClip Hit;
    public AudioClip Death;
}

