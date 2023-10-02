using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemAI : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float chaseRange = 5f;


    private NavMeshAgent enemyAgent;
    private float distanceToTarget = Mathf.Infinity;


    private void Awake()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        distanceToTarget = Vector3.Distance(target.position,transform.position);

        if (distanceToTarget <= chaseRange)
        {
            enemyAgent.SetDestination(target.position);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(1, 0, 0, 0.6F);
        Gizmos.DrawSphere(transform.position, chaseRange);
    }
}
