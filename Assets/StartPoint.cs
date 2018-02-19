using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour {
	[SerializeField] private GameObject playerPrefab;
	private GameObject _player;

	private int _maxFactorX;
	private int _cellScale = 5;

	void Start () {
		MazeGenerator generator = GameObject.Find ("MazeGenerate").GetComponent<MazeGenerator> ();
		_maxFactorX = generator._width - 1;

		_player = Instantiate (playerPrefab) as GameObject;
		_player.transform.position = new Vector3Int (_cellScale * Random.Range(0, _maxFactorX), 1, 5);
	}
}
