using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	public float lookRadius = 10f;

	Transform target;
	UnityEngine.AI.NavMeshAgent agent;

	// Use this for initialization
	void Start ()
	{
		target = PlayerManager.instance.player.transform;
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

	// Update is called once per frame
	void Update () {
		float distance = Vector2.Distance(target.position, transform.position);

		if(distance <= lookRadius)
		{
			agent.SetDestination(target.position);

			if(distance <= agent.stoppingDistance)
			{
				// Attack the target
				// Face the target
			}
		}
	}
}
