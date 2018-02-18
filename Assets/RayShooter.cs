using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour {
	// Объявляем ссылку на компонент
	private Camera _camera;

	void Start () {
		_camera = GetComponent<Camera> ();
		// Убираем курсор
		//Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void OnGUI() {
		int size = 12;
		float posX = _camera.pixelWidth / 2 - size / 4;
		float posY = _camera.pixelHeight / 2 - size / 2;
		// Выводим символ в центре экрана
		GUI.Label (new Rect (posX, posY, size, size), "*");
	}
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			// Определяем точку центра экрана
			Vector3 point = new Vector3 (_camera.pixelWidth / 2, _camera.scaledPixelHeight / 2, 0);
			// Создаем луч
			Ray ray = _camera.ScreenPointToRay(point);
			Debug.Log (point);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				// Определяем объект попадания луча
				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget> ();
				// Проверяем попадание в цель
				if (target != null) {
					target.ReactToHit ();
					//Debug.Log ("Target hit");
				} else {
					StartCoroutine (SphereIndicator (hit.point));
					Debug.Log ("Hit " + hit.point);
				}
			}
		}
	}

	private IEnumerator SphereIndicator(Vector3 pos) {
		GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		sphere.transform.position = pos;
		//Останавливаем сопрограмму
		yield return new WaitForSeconds (1);
		Destroy (sphere);
	}
}
