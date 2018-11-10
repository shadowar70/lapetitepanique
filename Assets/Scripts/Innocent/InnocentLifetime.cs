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
	private EnemyGenerator enemyGenerator;

    private bool isDying = false;
    public GameObject soulInnoncentPrefab;
    public GameObject soulMonsterPrefab;
    private float scoreMultiplier;

    private SpriteRenderer rendererBody;

    void Awake()
	{
		animator = GetComponent<Animator>();
		enemyGenerator = FindObjectOfType<EnemyGenerator>();
	}

	void Start()
	{
		startTime = Time.time;
        rendererBody = GetComponent<SpriteRenderer>();

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
        StartCoroutine(DeathStarting());

        StartCoroutine(WaitBeforeDeathState());

	}
	
	IEnumerator WaitBeforeDeathState()
	{
		yield return new WaitForSeconds(dyingTime);
		
		if(enemyGenerator != null)
		{
            Instantiate(soulMonsterPrefab, transform.position, Quaternion.identity);
            enemyGenerator.GenerateEnemy(transform.position, transform.rotation);
		}
		
		Destroy(gameObject);
	}

    IEnumerator DeathStarting() {
        float i = 0;
        bool isRed = false;

        while (true) {

            i += 0.1f;
            if (isRed) {
                rendererBody.color = Color.Lerp(rendererBody.color, Color.white, i);
            }
            else {
                rendererBody.color = Color.Lerp(rendererBody.color, Color.red, i);
            }

            if(i> 1 && isRed) {
                isRed = false;
                i = 0;
            }else if (i > 1 && !isRed) {
                isRed = true;
                i = 0;
            }

            //rendererBody.color = Color.Lerp(rendererBody.color, Color.red, i);

            yield return new WaitForSeconds(0.02f);
        }

    }

    public bool Die() {
        if (isDying) {
            Instantiate(soulInnoncentPrefab, transform.position, Quaternion.identity);
        }
        return isDying;
    }

    public float GetScore() {
        return (scoreMultiplier / dyingTime)*2;
    }
}
