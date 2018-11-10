using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Increase Character Count Event", menuName = "Event/Increase Character Count Event", order = 1)]
public class IncreaseCharacterCountEvent : AbstractEvent
{
	public float time = 10f;
	public int characterCountIncrease = 15;

    public override string Label => "Foule";

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
        manager.StartCoroutine(IncreaseCharacterCount());
    }

	public IEnumerator IncreaseCharacterCount()
	{
		GeneratorManager.desiredCharacterNumber += characterCountIncrease;
		yield return new WaitForSeconds(time);
		GeneratorManager.desiredCharacterNumber -= characterCountIncrease;
	}
}
