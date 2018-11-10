using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
	[Serializable]
	public class PrefabFrequency
	{
		public GameObject prefab = null;
		public float frequency = 1;
	}

	public PrefabFrequency[] prefabs = new PrefabFrequency[0];
	
	public IReadOnlyList<GameObject> GeneratedEnemies
	{
		get
		{
			return generatedEnemies;
		}
	}

	private List<GameObject> generatedEnemies = new List<GameObject>();
	private float totalFrequency = 0f;

	void Start ()
	{
		totalFrequency = prefabs.Select(e => e.frequency).Sum();
	}
	
	void Update ()
	{
		var destroyedGameObjects = generatedEnemies.Where(e => e == null).ToList();
		foreach(var destroyedGameObject in destroyedGameObjects)
		{
			generatedEnemies.Remove(destroyedGameObject);
		}
	}

	public GameObject GenerateEnemy(Vector3 position, Quaternion rotation)
	{
		var prefab = GetRandomPrefab();
		var enemy = Instantiate(prefab, position, rotation);
		generatedEnemies.Add(enemy);

		return enemy;
	}

	GameObject GetRandomPrefab()
	{
		var randomNumber = UnityEngine.Random.Range(0f, totalFrequency);

		var frequencyOffset = 0f;
		foreach(var prefabFrequency in prefabs)
		{
			if(frequencyOffset <= randomNumber && randomNumber <= frequencyOffset + prefabFrequency.frequency)
			{
				return prefabFrequency.prefab;
			}

			frequencyOffset += prefabFrequency.frequency;
		}

		return prefabs.Select(e => e.prefab).FirstOrDefault();
	}
}
