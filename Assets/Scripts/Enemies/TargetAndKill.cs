using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TargetAndKill : MonoBehaviour
{
	public float cooldown = 1f;

    private NavMeshAgent navMeshAgent = null;
	private GeneratorManager generatorManager;
	private GameObject target;

	void Awake()
	{
        navMeshAgent = GetComponent<NavMeshAgent>();
		generatorManager = FindObjectOfType<GeneratorManager>();
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
			Destroy(target);
		}
    }

	IEnumerator WaitAndTarget()
	{
		yield return new WaitForSeconds(cooldown);
		target = generatorManager.GeneratedCharacters[Random.Range(0, generatorManager.GeneratedCharacters.Count)];
	}
}
