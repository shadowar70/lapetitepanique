using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimatorAfterDelay : MonoBehaviour
{
	public float cooldown = 6f;
	public string targetTag = "";
	public string triggerName = "Show";

	void Start()
	{
		StartCoroutine(WaitAndTrigger());
	}

	void OnDisable()
	{
		StopAllCoroutines();
	}

	void OnDestroy()
	{
		StopAllCoroutines();
	}

	IEnumerator WaitAndTrigger()
	{
		while(true)
		{
			yield return new WaitForSeconds(cooldown);
			var gameObject = GameObject.FindGameObjectWithTag("SplashFx");
			if(gameObject != null)
			{
				var animator = gameObject.GetComponent<Animator>();
				animator?.SetTrigger(triggerName);
			}
		}
	}
}
