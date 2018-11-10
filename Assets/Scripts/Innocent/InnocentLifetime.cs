using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class InnocentLifetime : MonoBehaviour
{
	public float healthyTime = 10f;
	public float dyingTime = 3f;

	private float startTime = 0f;
	private Animator animator;

	void Awake()
	{
		animator = GetComponent<Animator>();
	}

	void Start()
	{
		startTime = Time.time;
		StartCoroutine(WaitBeforeDyingState());
	}
	
	IEnumerator WaitBeforeDyingState()
	{
		yield return new WaitForSeconds(healthyTime);
		animator.SetBool("Dying", true);

		StartCoroutine(WaitBeforeDeathState());

	}
	
	IEnumerator WaitBeforeDeathState()
	{
		yield return new WaitForSeconds(dyingTime);
		Destroy(gameObject);
	}
}
