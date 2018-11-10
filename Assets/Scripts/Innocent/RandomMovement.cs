using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class RandomMovement : MonoBehaviour
{
    public float range = 30.0f;

    private NavMeshAgent navMeshAgent = null;
    private float direction;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        direction = Random.value;
    }

    void Update ()
	{
        // Check if we've reached the destination
        if (!navMeshAgent.pathPending)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    navMeshAgent.SetDestination(RandomNavmeshLocation(range));
                }
            }
        }
    }

    public Vector3 RandomNavmeshLocation(float radius)
    {
        var direction = Random.insideUnitCircle;
        Vector3 randomDirection = transform.position + new Vector3(direction.x, 0, direction.y)  * radius;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }

        return finalPosition;
    }
}
