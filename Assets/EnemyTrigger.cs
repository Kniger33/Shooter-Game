using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTrigger : MonoBehaviour {

	void Start () {
		
	}

	void OnTriggerEnter (Collider  other) {
		if (other.tag == "Player") {
			Debug.Log ("Player enter");

			EnemyNavigation navigation = GetComponentInParent<EnemyNavigation> ();
			WanderingAI behavior = GetComponentInParent<WanderingAI> ();

			navigation._target = other.gameObject;
			behavior.Shoot (true);
		}
	}

	void OnTriggerStay (Collider other) {
		if (other.tag == "Player") {
			Debug.Log ("Player stay");
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.tag == "Player") {
			Debug.Log ("Player exit");

			EnemyNavigation navigation = GetComponentInParent<EnemyNavigation> ();
			WanderingAI behavior = GetComponentInParent<WanderingAI> ();

			behavior.Shoot (false);
			navigation._target = null;
		}
	}
}
