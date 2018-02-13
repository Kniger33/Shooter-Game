using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour {
	// Определяем скорость и расстояние реакции
	public float speed = 3.0f;
	public float obstacleRange = 5.0f;
	private bool _alive = true;

	// Определяем ссылку на снаряд
	[SerializeField] private GameObject fireballPrefab;
	private GameObject _fireball;

	void Update () {
		if (_alive) {
			// Описываем движение
			transform.Translate (0, 0, speed * Time.deltaTime);

			// Описываем движение луча
			Ray ray = new Ray (transform.position, transform.forward);
			RaycastHit hit;

			// Бросаем луч
			if (Physics.SphereCast (ray, 0.75f, out hit)) {
				GameObject hitObject = hit.transform.gameObject;

				// Проверка попадания луча в игрока
				if (hitObject.GetComponent<PlayerCharacter> ()) {
					if (_fireball == null) {
						_fireball = Instantiate (fireballPrefab) as GameObject;
						// Создаем и направляем снаряд
						_fireball.transform.position = transform.TransformPoint (Vector3.forward * 1.5f);
						_fireball.transform.rotation = transform.rotation;
					}
				} 
				// Проверка препятствия и избежание столкновения
				else if (hit.distance < obstacleRange) {
					float angle = Random.Range (-110, 110);
					transform.Rotate (0, angle, 0);
				}
			}
		}
	}

	public void SetAlive(bool alive) {
		_alive = alive;
	}
}
