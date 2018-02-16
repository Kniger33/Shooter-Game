using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour {
	private GameObject _target;
	private NavMeshAgent navigate;
	private GameObject _player;

	void Start () {
		this.gameObject.GetComponent<NavMeshAgent> ().enabled = false;
		this.gameObject.GetComponent<NavMeshAgent> ().enabled = true;
		navigate = GetComponent<NavMeshAgent> ();
		_player = GameObject.FindWithTag ("Player");
		_target = _player;
		//this.gameObject.GetComponent<NavMeshAgent> ().avoidancePriority = Random.Range (0, 100);
	}

	void Update () {
		if (_target) {
			navigate.SetDestination (_target.transform.position);
		}
	}
}