using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;

    [SerializeField] private GameObject scoreProfit;
    private int scoreAdd;

    [SerializeField] private GameObject scoreText;
    private int score;

    [SerializeField] private int scoreNeeded;

    [SerializeField] private GameObject powerText;
    [SerializeField] int powerAmount;

    private ScoreSound sound;

    private float divCount;
    private void Awake()
    {
        if (Instance != null) Destroy(this);
        else Instance = this;
        scoreProfit.SetActive(false);
        score = 0;
        scoreText.SetActive(true);
        scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString() + " / " + scoreNeeded;
        sound = gameObject.GetComponent<ScoreSound>();
        divCount = 0;
    }

    public void ShowAddScore()
    {
        scoreAdd = Random.Range(50, 101);
        UpdateScore(scoreAdd);
        scoreProfit.GetComponent<TextMeshProUGUI>().text = "+ " + scoreAdd;
        scoreProfit.SetActive(true);
        StartCoroutine(Waiter());
    }

    private void UpdateScore(int scoreAdd)
    {
        score += scoreAdd;
        PlaySound();
        scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString() + " / " + scoreNeeded;
        if(score >= scoreNeeded)
        {
            divCount = 0;
            PlayerMovement.instance.startLaunchPower += powerAmount;
            PlayerMovement.instance.maxLaunchPower += powerAmount;
            score = 0;
            scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString() + " / " + scoreNeeded;
            powerText.GetComponent<TextMeshProUGUI>().text = "+ " + powerAmount + " POWER";
            powerText.SetActive(true);
            StartCoroutine(WaiterPower());
        }
    }

    private void PlaySound()
    {
        if(divCount+1 == score / 1000)
        {
            divCount++;
            sound.Reset();
            sound.PlayClip(0);
        }
        else sound.PlayClip(1);
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(.5f);
        scoreProfit.SetActive(false);
    }

    IEnumerator WaiterPower()
    {
        yield return new WaitForSeconds(.5f);
        powerText.SetActive(false);
    }
}



