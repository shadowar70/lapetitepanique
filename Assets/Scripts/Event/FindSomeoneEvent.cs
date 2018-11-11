using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Find Someone Event", menuName = "Event/Find Someone Event", order = 1)]
public class FindSomeoneEvent : AbstractEvent
{
	public float time = 7f;
	public GameObject prefab = null;

    public override string Label => "Trouvez Charlie";

	private GameObject generatedCharacter = null;

    public override void Execute(EventManager manager)
    {
        manager.StartCoroutine(IncreaseCharacterCount());
    }

	public IEnumerator IncreaseCharacterCount()
	{
		generatedCharacter = GameObject.Instantiate(prefab, RandomNavmeshLocation(100f), prefab.transform.rotation);
		yield return new WaitForSeconds(time);
		Destroy(generatedCharacter);
	}

    public Vector3 RandomNavmeshLocation(float radius)
    {
        var direction = Random.insideUnitCircle;
        Vector3 randomDirection = Vector3.zero;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }

        return finalPosition;
    }
}
