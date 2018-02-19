using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
		
		[SerializeField] private GameObject enemyPrefab;
		private GameObject _enemy;

		public int enemyCount = 5;
		private int _count = 0;

		//private float _angle;

		private int _cellScale = 5;
		private int _maxFactorX;
		private int _maxFactorZ;

		void Start () {
			MazeGenerator generator = GameObject.Find ("MazeGenerate").GetComponent<MazeGenerator> ();
			_maxFactorX = generator._width - 1;
			_maxFactorZ = generator._height;
		}

		void Update () {
			if (_count < enemyCount) {
				Spawn ();
				_count++;
			}
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

		void Spawn () {
			_enemy = Instantiate (enemyPrefab) as GameObject;
			_enemy.transform.position = new Vector3Int (_cellScale * Random.Range(0, _maxFactorX), 1, _cellScale * Random.Range(2, _maxFactorZ));

			//_angle = Random.Range (0, 360);
			//_enemy.transform.Rotate (0, _angle, 0);
			//_count += 1;
		}
}


