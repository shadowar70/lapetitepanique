using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnDestroyed : MonoBehaviour
{
	public string audioSourceTag = null;
	public AudioClip[] audioClips = new AudioClip[0];

	private AudioSource audioSource;

	void Awake()
	{
		audioSource = GameObject.FindGameObjectWithTag(audioSourceTag).GetComponent<AudioSource>();
	}

	void OnDestroy()
	{
		if(audioSource != null && !audioSource.isPlaying)
		{
			audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
		}
	}
}
