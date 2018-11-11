using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EventManager : MonoBehaviour
{
	public AbstractEvent[] events = new AbstractEvent[0];
	public float minTimeBetweenEvents = 30f;
	public float maxTimeBetweenEvents = 60f;
	public UnityEngine.UI.Text eventText = null;
	public Animator eventAnimator = null;

	public delegate void EventStartedDelegate(AbstractEvent eventt);
	public event EventStartedDelegate EventStarted;

	private AudioSource audioSource = null;

	void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void Start()
	{
		StartCoroutine(WaitAndLaunchNextEvent());
	}

	IEnumerator WaitAndLaunchNextEvent()
	{
		while(true)
		{
			var timeBeforeNextEvent = Random.Range(minTimeBetweenEvents, maxTimeBetweenEvents);
			yield return new WaitForSeconds(timeBeforeNextEvent);
			StartNewEvent();
		}
	}

	void StartNewEvent()
	{
		var index = UnityEngine.Random.Range(0, events.Length);
		var myEvent = events[index];
		eventText.text = myEvent.Label;
		eventAnimator.SetTrigger("Show");
		myEvent.Execute(this);
		audioSource.PlayOneShot(myEvent.audio);
	}
}
