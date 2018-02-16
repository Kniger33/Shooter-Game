using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour {

	public void ReactToHit() {
		WanderingAI behavior = GetComponent<WanderingAI> ();
		EnemyNavigation access = GetComponent<EnemyNavigation> ();

		if (behavior != null) {
			behavior.SetAlive (false);
		}
		StartCoroutine (Die());
	}

	private IEnumerator Die() {
		//this.transform.Rotate (-75, 0, 0);
		yield return new WaitForSeconds (0f);
		Destroy (this.gameObject);
	}
}
