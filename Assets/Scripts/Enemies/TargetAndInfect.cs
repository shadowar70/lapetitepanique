using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TargetAndInfect : MonoBehaviour
{
	public float cooldown = 1f;

    private NavMeshAgent navMeshAgent = null;
	private GeneratorManager generatorManager;
	private GameObject target;
	private EnemyGenerator enemyGenerator;

	void Awake()
	{
        navMeshAgent = GetComponent<NavMeshAgent>();
		generatorManager = FindObjectOfType<GeneratorManager>();
		enemyGenerator = FindObjectOfType<EnemyGenerator>();
	}

	void Update ()
	{
		if(target != null)
		{
            navMeshAgent.SetDestination(target.transform.position);
		}
		else
		{
			StartCoroutine(WaitAndTarget());
		}
	}
	
	void OnCollisionEnter(Collision collision)
    {
		if(collision.gameObject == target)
		{
			enemyGenerator.GenerateEnemy(collision.gameObject.transform.position, collision.gameObject.transform.rotation);
			Destroy(target);
		}
    }

	IEnumerator WaitAndTarget()
	{
		yield return new WaitForSeconds(cooldown);
		target = generatorManager.GeneratedCharacters[Random.Range(0, generatorManager.GeneratedCharacters.Count)];
	}
}
