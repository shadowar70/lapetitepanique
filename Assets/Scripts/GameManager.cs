using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public float timerScore = 120f;
    [SerializeField] Text scoreValue;
    [SerializeField] Text timerValue;
    [SerializeField] Text multiplierValue;

    public GameObject menuGameOver;


    void Start () {
        instance = this;
		
	}
	

	void FixedUpdate () {

        timerScore -= Time.fixedDeltaTime;

        if(timerScore <= 0) {
            menuGameOver.SetActive(true);
            Time.timeScale = 0;
        }

        timerValue.text = "" + (int)timerScore;

    }

    public void ImpactTimerScore(float impact) {
        timerScore += impact;
    }

    public void UpdateScoreAndMultiplier(int score, int multiplier) {
        scoreValue.text = "" + score;
        multiplierValue.text = "" + multiplier;
    }
}
