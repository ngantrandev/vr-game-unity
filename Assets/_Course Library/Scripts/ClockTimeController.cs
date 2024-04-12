using System;
using UnityEngine;

public class ClockTimeController : MonoBehaviour
{
    // movement in degree of secondhand, minurehand and hourhand;
    // round digit = 8
    private readonly float SECOND_HAND_DEGREE = (float)Math.Round(360f / 60f, 8);
    private readonly float MINUTE_HAND_DEGREE = (float)Math.Round(360f / (60f * 60f), 8);
    private readonly float HOUR_HAND_DEGREE = (float)Math.Round(360f / (12f * 60f * 60f), 8);

    [SerializeField] private GameObject secondHand;
    [SerializeField] private GameObject minuteHand;
    [SerializeField] private GameObject hourHand;
    [SerializeField] private AudioClip sfxClockTick1;
    [SerializeField] private AudioClip sfxClockTick2;
    private AudioSource audioSource;
    private int currTimeInSeconds = 0;
    private int preTimeInSeconds = 0;


    // play audio1 if true and audio2 if false
    // random interger between 0 and 1
    private bool isPlayAudio1 = new System.Random().Next(2) == 1;

    // Update is called once per frame
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        ConvertTimeToSeconds();

        RotateClockHand();

    }

    private void RotateClockHand()
    {
        if (currTimeInSeconds != preTimeInSeconds)
        {
            secondHand.transform.localRotation = Quaternion.Euler(currTimeInSeconds * SECOND_HAND_DEGREE, 0, 0);
            minuteHand.transform.localRotation = Quaternion.Euler(currTimeInSeconds * MINUTE_HAND_DEGREE, 0, 0);
            hourHand.transform.localRotation = Quaternion.Euler(currTimeInSeconds * HOUR_HAND_DEGREE, 0, 0);

           Debug.Log(currTimeInSeconds * SECOND_HAND_DEGREE + " : " + currTimeInSeconds * MINUTE_HAND_DEGREE + " : " + currTimeInSeconds * HOUR_HAND_DEGREE);

            PlayAudio();
        }

        preTimeInSeconds = currTimeInSeconds;

    }

    private void PlayAudio()
    {
        if (isPlayAudio1)
        {
            audioSource.PlayOneShot(sfxClockTick1);
        }
        else
        {
            audioSource.PlayOneShot(sfxClockTick2);
        }

        isPlayAudio1 = !isPlayAudio1;
    }

    private int ConvertTimeToSeconds()
    {
        int currSecond = DateTime.Now.Second;
        int currMinute = DateTime.Now.Minute;
        int currHour = DateTime.Now.Hour;

        Debug.Log(currSecond);
        Debug.Log(currMinute);
        Debug.Log(currHour);
        Debug.Log("");

        

        if (currHour > 12)
        {
            currHour -= 12;
        }

        currTimeInSeconds = currSecond + currMinute * 60 + currHour * 3600;

        return currTimeInSeconds;
    }
}