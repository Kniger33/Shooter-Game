using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Control Scripts/MouseLook")]

public class MouseLook : MonoBehaviour {
	// Объявляем оси
	public enum RotationAxes
	{
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}
	public RotationAxes axes = RotationAxes.MouseXAndY;

	// Объявляем скорость вращения
	public float sensitivityHor = 9.0f;
	public float sensitivityVert = 9.0f;

	// Объявляем ограничения на вращение в вертикальной плоскости
	public float minimumVert = -45.0f;
	public float maximumVert = 45.0f;

	// Угол наклона
	private float _rotationX = 0;

	void Start() {
		Rigidbody body = GetComponent<Rigidbody> ();
		if (body != null)
			body.freezeRotation = true;
	}

	void Update () {
		// Поворот в горизонтальной плоскости
		if (axes == RotationAxes.MouseX) {
			transform.Rotate (0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
		} 

		// Поворот в вертикальной плоскости
		else if (axes == RotationAxes.MouseY) {
			// Увеличиваем угол
			_rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;
			// Фиксируем угол в диапазоне
			_rotationX = Mathf.Clamp (_rotationX, minimumVert, maximumVert);
			// Сохраняем угол поворота
			float rotationY = transform.localEulerAngles.y;
			// Создаем вектор
			transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
		}

		// Поворот в оюоих плоскостях
		else {
			// Увеличиваем угол
			_rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;
			// Фиксируем угол в диапазоне
			_rotationX = Mathf.Clamp (_rotationX, minimumVert, maximumVert);
			// Увеличение угла
			float delta = Input.GetAxis("Mouse X") * sensitivityHor;
			float rotationY = transform.localEulerAngles.y + delta;
			// Создаем вектор
			transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
		}

	}
}
