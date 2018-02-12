using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Scripts/FPS Input")]

public class FPSInput : MonoBehaviour {
	// Объявляем скорость
	public float speed = 6.0f;
	// Вводим гравитацию
	public float gravity = -9.8f;

	// Объявляем ссылку на компонент
	private CharacterController _charController;

	void Start () {
		_charController = GetComponent<CharacterController> ();
	}

	void Update () {
		// Определяем движения
		float deltaX = Input.GetAxis ("Horizontal") * speed;
		float delatZ = Input.GetAxis ("Vertical") * speed;

		Vector3 movement = new Vector3 (deltaX, 0, delatZ);

		// Ограничиваем скорость
		movement = Vector3.ClampMagnitude (movement, speed);
		// Используем гравитацию
		movement.y = gravity;
		movement *= Time.deltaTime;

		// Преобразуем вектор
		movement = transform.TransformDirection (movement);
		_charController.Move (movement);
	}
}
