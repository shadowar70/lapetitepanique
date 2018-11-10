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


    void Start () {
        instance = this;
		
	}
	

	void FixedUpdate () {

        timerScore -= Time.fixedDeltaTime;

        if(timerScore <= 0) {
            Debug.Log("PERDU !");
        }

        timerValue.text = "" + (int)timerScore;

    }

    public void ImpactTimerScore(float impact) {

        timerScore += impact;
        Debug.Log("timerScore: " + timerScore);

    }

    public void UpdateScoreAndMultiplier(int score, int multiplier) {
        scoreValue.text = "" + score;
        multiplierValue.text = "" + multiplier;
    }
}
