using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Fill references")]
    [SerializeField] private GameObject gameOverObj;
    [SerializeField] private GameObject countdownObj;
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private TMP_Text scoreText;
    [Space]
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip startSound;
    [SerializeField] private AudioClip dieSound;

    //Enables the countdown UI text
    public void enableCountdown()
    {
        countdownObj.SetActive(true);
    }

    public void disableCountdown()
    {
        countdownObj.SetActive(false);
    }

    /// <summary>
    /// Sets the countdown text based on the percentage through the countdown
    /// </summary>
    /// <param name="phase"></param>
    /// <param name="totalPhase"></param>
    public void setCountdownPhase(float phase, float totalPhase)
    {
        if(phase < totalPhase * 0.25)
        {
            countdownText.text = "3";
        }
        else if(phase < totalPhase * 0.5)
        {
            countdownText.text = "2";
        }
        else if(phase < totalPhase * 0.75)
        {
            countdownText.text = "1";
        }
        else
        {
            countdownText.text = "GO!";
        }
    }

    public void setScoreUI(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void enableGameOver()
    {
        gameOverObj.SetActive(true);
    }

    //MANAGE THIS ELSEWHERE LATER
    public void playAudioStartGame()
    {
        source.PlayOneShot(startSound, 0.2f);
    }

    public void playAudioDie()
    {
        source.PlayOneShot(dieSound, 0.2f);
    }
}
