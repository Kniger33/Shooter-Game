using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour {
	private GameObject _target;
	private NavMeshAgent navigate;
	private GameObject _player;

	public float seeDistance = 10f;

	void Start () {
		navigate = GetComponent<NavMeshAgent> ();
		navigate.enabled = false;
		navigate.enabled = true;
		_player = GameObject.FindWithTag ("Player");
		//_target = _player;
		navigate.avoidancePriority = Random.Range (0, 100);
	}

	void Update () {
		WanderingAI behavior = GetComponent<WanderingAI> ();
		if (Vector3.Distance (transform.position, _player.transform.position) < seeDistance) {
			_target = _player;
			behavior.Shoot (true);
		} else {
			_target = null;
			behavior.Shoot (false);
		}

		if (_target) {
			navigate.SetDestination (_target.transform.position);
		}
	}
}