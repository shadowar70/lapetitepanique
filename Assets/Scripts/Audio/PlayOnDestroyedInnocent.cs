using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnDestroyedInnocent : MonoBehaviour {
    public string audioSourceTag = null;
    public AudioClip[] audioClipsInnocent = new AudioClip[0];
    public AudioClip[] audioClipsVictim = new AudioClip[0];

    private AudioSource audioSource;

    void Awake() {
        audioSource = GameObject.FindGameObjectWithTag(audioSourceTag).GetComponent<AudioSource>();
    }

    void OnDestroy() {
        if (audioSource != null && !audioSource.isPlaying) {


            if (GetComponent<InnocentLifetime>().GetIsDying()) {
                audioSource.PlayOneShot(audioClipsVictim[Random.Range(0, audioClipsVictim.Length)]);
            }
            else {
                audioSource.PlayOneShot(audioClipsInnocent[Random.Range(0, audioClipsInnocent.Length)]);

            }

        }
    }
}
