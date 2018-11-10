using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public float timerScore = 120f;

	void Start () {
        instance = this;
		
	}
	

	void Update () {

        timerScore -= Time.deltaTime;

        if(timerScore <= 0) {
            Debug.Log("PERDU !");
        }
		
	}

    public void ImpactTimerScore(float impact) {

        timerScore += impact;
        Debug.Log("timerScore: " + timerScore);

    }
}
