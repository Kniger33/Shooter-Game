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
	private float _spawnX;
	private float _spawnZ;

	public float areaOfSpawn = 8.0f;

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

			_enemy.transform.position = spawnLocations.transform.position;

			_spawnX = spawnLocations.transform.position.x + Random.Range (-areaOfSpawn, areaOfSpawn);
			_spawnZ = spawnLocations.transform.position.z + Random.Range (-areaOfSpawn, areaOfSpawn);

			_enemy.transform.position = new Vector3 (_spawnX, 1, _spawnZ);

			_angle = Random.Range (0, 360);
			_enemy.transform.Rotate (0, _angle, 0);

			_count += 1;
		}
	}
}
