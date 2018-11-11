using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public float timerScore = 120f;
    [SerializeField] private Text scoreValue;
    [SerializeField] private Text timerValue;
    [SerializeField] private Text multiplierValue;
    public Animator musicAnimator = null;
    public AudioSource musicSource = null;
    public AudioSource musicSourceMonster = null;

    private Text finalScoreValue;

    public GameObject menuGameOver;


    void Start () {
        finalScoreValue = menuGameOver.transform.GetChild(1).transform.GetChild(1).GetComponent<Text>();
        instance = this;
		
	}
	

	void FixedUpdate () {

        timerScore -= Time.fixedDeltaTime;

        if(timerScore <= 0) {
            finalScoreValue.text = scoreValue.text;
            menuGameOver.SetActive(true);
            Time.timeScale = 0;
            musicAnimator.enabled = false;
            musicSource.pitch = -0.4f;
            musicSourceMonster.volume = 0f;
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
