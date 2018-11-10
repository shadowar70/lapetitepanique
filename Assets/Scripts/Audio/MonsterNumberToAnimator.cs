using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MonsterNumberToAnimator : MonoBehaviour
{
	private Animator animator;
	private EnemyGenerator enemyGenerator;

	void Awake()
	{
		enemyGenerator = FindObjectOfType<EnemyGenerator>();
		animator = GetComponent<Animator>();
	}
	
	void Update()
	{
		animator.SetInteger("MonsterCount", enemyGenerator.GeneratedEnemies.Count);
	}
}
