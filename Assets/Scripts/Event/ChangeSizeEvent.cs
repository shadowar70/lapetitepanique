using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Change Size Event", menuName = "Event/Change Size", order = 1)]
public class ChangeSizeEvent : AbstractEvent
{
	public float time = 10f;
	public float sizeChangeTime = 0.7f;
	public float scaleFactor = 0.6f;

    public override string Label => "Rétrécissement";

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
        manager.StartCoroutine(ScaleCharacters());
    }

	public IEnumerator ScaleCharacters()
	{
		if(GeneratorManager.GeneratedCharacters.Count != 0)
		{
			var initScale = GeneratorManager.GeneratedCharacters[0].transform.localScale;
			var targetScale = GeneratorManager.GeneratedCharacters[0].transform.localScale * scaleFactor;

			var transformationTime = 0f;
			while(transformationTime < sizeChangeTime)
			{
				transformationTime += Time.deltaTime;
				foreach(var character in GeneratorManager.GeneratedCharacters)
				{
					if(character != null)
					{
						character.transform.localScale = Vector3.Lerp(initScale, targetScale, transformationTime / sizeChangeTime);
					}
				}
				yield return new WaitForEndOfFrame();
			}

			yield return new WaitForSeconds(time - 2f * sizeChangeTime);
			
			transformationTime = 0f;
			while(transformationTime < sizeChangeTime)
			{
				transformationTime += Time.deltaTime;
				foreach(var character in GeneratorManager.GeneratedCharacters)
				{
					if(character != null)
					{
						character.transform.localScale = Vector3.Lerp(targetScale, initScale, transformationTime / sizeChangeTime);
					}
				}
				yield return new WaitForEndOfFrame();
			}
		}

	}
}
