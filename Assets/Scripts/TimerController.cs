using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour {

    public float timerScore = 0;

	void Start () {
		
	}
	
	
	void Update () {

        timerScore -= Time.deltaTime;



	}
}
