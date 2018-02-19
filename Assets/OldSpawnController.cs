using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class OldSpawnController : MonoBehaviour {
	public Transform[] spawnLocations;
	[SerializeField] private GameObject enemyPrefab;
	private GameObject _enemy;

	public int enemyCount = 5;
	private int _count = 0;
		
	private float _angle;
	private float _spawnX;
	private float _spawnZ;

	public float spawnArea = 8f;

	private int _countLocations;

	void Start () {
		_countLocations = spawnLocations.Length;
		for (int i = 0; i < _countLocations; i++) {
			Spawn (spawnLocations [i]);
		}
	}
		
	void Update () {
		/*
		SceneController behavior = GetComponentInParent<SceneController> ();
		if (_enemy == null) {
			Debug.Log ("null");
			behavior.ActiveEnemy (false);
		} else {
			Debug.Log ("Yes");
			behavior.ActiveEnemy (true);
		}
		*/
	}

	void Spawn (Transform spawnLocations) {
		_count = 0;
		while (_count < enemyCount) {
			_spawnX = spawnLocations.transform.position.x + Random.Range (-spawnArea, spawnArea);
			_spawnZ = spawnLocations.transform.position.z + Random.Range (-spawnArea, spawnArea);

			_enemy = Instantiate (enemyPrefab) as GameObject;
			_enemy.transform.transform.position = new Vector3 (_spawnX, 1, _spawnZ);

			_angle = Random.Range (0, 360);
			_enemy.transform.Rotate (0, _angle, 0);
			_count += 1;
		}
	}
}
