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

    private bool isDying = false;
    public GameObject soulPrefab;
    private float scoreMultiplier;

    void Awake()
	{
		animator = GetComponent<Animator>();
	}

	void Start()
	{
		startTime = Time.time;
		StartCoroutine(WaitBeforeDyingState());

	}

    private void Update() {
        if (isDying) {
            scoreMultiplier += Time.deltaTime;
        }
    }

    IEnumerator WaitBeforeDyingState()
	{
		yield return new WaitForSeconds(healthyTime);

        isDying = true;
        animator.SetBool("Dying", true);

		StartCoroutine(WaitBeforeDeathState());

	}
	
	IEnumerator WaitBeforeDeathState()
	{
		yield return new WaitForSeconds(dyingTime);
		Destroy(gameObject);
	}

    public bool Die() {
        if (isDying) {
            //Instantiate Monster
        }
        else {
            Instantiate(soulPrefab, transform.position, Quaternion.identity);
        }
        return isDying;
    }

    public float GetScore() {
        return (scoreMultiplier / dyingTime)*2;
    }
}
