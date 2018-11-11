using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimatorAfterDelay : MonoBehaviour
{
	public float cooldown = 6f;
	public string targetTag = "";
	public string triggerName = "Show";
    public string audioSourceTag = null;
    private AudioSource audioSource;
    public AudioClip[] audioClips = new AudioClip[0];
    public Animator mouthAnimator;


    void Start()
	{
        if(audioSourceTag != null) {
            audioSource = GameObject.FindGameObjectWithTag(audioSourceTag).GetComponent<AudioSource>();
        }
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
                if (audioSource != null && !audioSource.isPlaying) {
                    audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
                }

                if(mouthAnimator != null) {
                    mouthAnimator.SetTrigger("Vomit");
                }

                var animator = gameObject.GetComponent<Animator>();
				animator?.SetTrigger(triggerName);
			}
		}
	}
}
