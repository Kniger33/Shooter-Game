using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpenDoor : MonoBehaviour {
	public GameObject openTarget;

	void OnCollisionEnter (Collision Col) {

		if (Col.gameObject.name == "Player") {
			this.gameObject.GetComponent<Collider> ().enabled = false;
		}
	}
}
