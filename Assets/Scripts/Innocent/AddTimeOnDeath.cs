using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTimeOnDeath : MonoBehaviour
{
	public float timeBonus = 20f;

	void OnDestroy()
	{
		GameManager.instance.ImpactTimerScore(timeBonus);
	}
}
