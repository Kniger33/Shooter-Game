using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {
	public GameObject gateDoor;
	private int _health;

	void Start () {
		_health = 5;
	}

	void OnCollisionEnter (Collision Col) {
		if (Col.gameObject.name == "GateDoor") {
			gateDoor.GetComponent<Collider> ().enabled = false;
		}
	}

	public void Hurt(int damage) {
		_health -= damage;
		Debug.Log ("Health: " + _health);
	}
}
