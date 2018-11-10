using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GeneratorManager : MonoBehaviour
{
	[Serializable]
	public class PrefabFrequency
	{
		public GameObject prefab = null;
		public float frequency = 1;
	}

	public int desiredCharacterNumber = 25;
	public AbstractGenerator[] generators = new AbstractGenerator[0];
	public PrefabFrequency[] characterPrefabs = new PrefabFrequency[0];
	
	private List<GameObject> generatedCharacters = new List<GameObject>();
	private float totalFrequency = 0f;

	void Start ()
	{
		totalFrequency = characterPrefabs.Select(e => e.frequency).Sum();
	}
	
	void Update ()
	{
		var destroyedGameObjects = generatedCharacters.Where(e => e == null).ToList();
		foreach(var destroyedGameObject in destroyedGameObjects)
		{
			generatedCharacters.Remove(destroyedGameObject);
		}

		for(var i = generatedCharacters.Count; i < desiredCharacterNumber; i++)
		{
			var character = GenerateCharacter();
			generatedCharacters.Add(character);
		}
	}

	GameObject GenerateCharacter()
	{
		var generator = GetRandomGenerator();
		var prefab = GetRandomPrefab();
		
		return generator.GenerateCharacter(prefab);
	}

	AbstractGenerator GetRandomGenerator()
	{
		return generators[UnityEngine.Random.Range(0, generators.Length)];
	}

	GameObject GetRandomPrefab()
	{
		var randomNumber = UnityEngine.Random.Range(0f, totalFrequency);

		var frequencyOffset = 0f;
		foreach(var prefabFrequency in characterPrefabs)
		{
			if(frequencyOffset <= randomNumber && randomNumber <= frequencyOffset + prefabFrequency.frequency)
			{
				return prefabFrequency.prefab;
			}

			frequencyOffset += prefabFrequency.frequency;
		}

		return characterPrefabs.Select(e => e.prefab).FirstOrDefault();
	}
}
