using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Change Speed Event", menuName = "Event/Change Speed", order = 1)]
public class ChangeSpeedEvent : AbstractEvent
{
	public float time = 10f;
	public float speedFactor = 1.7f;

    public override string Label => "Panique";

	private GeneratorManager generatorManager = null;
	private GeneratorManager GeneratorManager
	{
		get
		{
			if(generatorManager == null)
			{
				generatorManager = FindObjectOfType<GeneratorManager>();
			}

			return generatorManager;
		}
	}

    public override void Execute(EventManager manager)
    {
        manager.StartCoroutine(SpeedUpCharacters());
    }

	public IEnumerator SpeedUpCharacters()
	{
		foreach(var character in GeneratorManager.GeneratedCharacters)
		{
			character.GetComponent<NavMeshAgent>().speed *= speedFactor;
			character.GetComponent<NavMeshAgent>().acceleration *= speedFactor;
		}

		yield return new WaitForSeconds(time);
		
		foreach(var character in GeneratorManager.GeneratedCharacters)
		{
			character.GetComponent<NavMeshAgent>().speed /= speedFactor;
			character.GetComponent<NavMeshAgent>().acceleration /= speedFactor;
		}
	}
}
