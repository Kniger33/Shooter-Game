using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
	// Создание связи с шаблоном
	[SerializeField] private GameObject enemyPrefab;
	private GameObject _enemy;
	private float angle;

	void Update () {
		// Спавн врагов по условию
		if (_enemy == null) {
			_enemy = Instantiate (enemyPrefab) as GameObject;
			_enemy.transform.transform.position = new Vector3 (0, 1, 0);
			angle = Random.Range (0, 360);
			_enemy.transform.Rotate (0, angle, 0);
		}
	}
}
