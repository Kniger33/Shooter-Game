using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour {

	private int _cellScale = 5;
	private int _maxFactorX;

	void Start () {
		MazeGenerator generator = GameObject.Find ("MazeGenerate").GetComponent<MazeGenerator> ();
		_maxFactorX = generator._width - 1;
		transform.position = new Vector3Int (_cellScale * Random.Range(0, _maxFactorX), 2, 50);
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			Debug.Log ("FIHISH");
		}
	}
}
