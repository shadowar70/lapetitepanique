using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTeleportAndKill : MonoBehaviour
{
	public float cooldown = 5f;
	public ParticleSystem teleportationParticles;

    private UnityEngine.AI.NavMeshAgent navMeshAgent = null;
	private GeneratorManager generatorManager;
	private GameObject target;

	void Awake()
	{
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
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
			target = null;
		}
    }

	IEnumerator WaitAndTarget()
	{
		if(generatorManager.GeneratedCharacters.Count != 0)
		{
			target = generatorManager.GeneratedCharacters[Random.Range(0, generatorManager.GeneratedCharacters.Count)];
			yield return new WaitForSeconds(cooldown);
			Teleport(target.transform.position);
			yield return new WaitForEndOfFrame();
		}
	}

	void Teleport(Vector3 position)
	{
		transform.position = position;
		teleportationParticles.Play();
	}
}
