using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SpawnController : MonoBehaviour {
	public Transform[] spawnLocations;
	[SerializeField] private GameObject enemyPrefab;
	private GameObject _enemy;

	public int enemyCount = 5;
	private int _count = 0;
		
	private float _angle;
	private int _countLocations;

	void Start () {
		_countLocations = spawnLocations.Length;
		for (int i = 0; i < _countLocations; i++) {
			Spawn (spawnLocations [i]);
		}
	}
		
	void Update () {
		SceneController behavior = GetComponentInParent<SceneController> ();
		if (_enemy == null) {
			Debug.Log ("null");
			behavior.ActiveEnemy (false);
		} else {
			Debug.Log ("Yes");
			behavior.ActiveEnemy (true);
		}
	}

	void Spawn (Transform spawnLocations) {
		_count = 0;
		while (_count < enemyCount) {
			_enemy = Instantiate (enemyPrefab) as GameObject;
			_enemy.transform.transform.position = spawnLocations.transform.position;
			_angle = Random.Range (0, 360);
			//_enemy.transform.Rotate (0, _angle, 0);
			_count += 1;
		}
	}
}
