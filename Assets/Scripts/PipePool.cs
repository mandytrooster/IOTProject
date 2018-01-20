using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePool : MonoBehaviour {

	public int pipePoolSize = 5;
	public GameObject pipePrefab;
	public float spawnRate = 4f;
	public float pipeMin;
	public float pipeMax;

	private Vector2 poolPosition = new Vector2 (-15f, -15f);
	private GameObject[] pipes;
	private float timeSinceSpawned;
	private float spawnXPos = 10f;
	private int currentPipe = 0;

	void Start () {

		pipes = new GameObject[pipePoolSize];
		for (int i = 0; i < pipePoolSize; i++) {
			pipes [i] = (GameObject)Instantiate (pipePrefab, poolPosition, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceSpawned += Time.deltaTime;

		if (GameController.instance.gameOver == false && timeSinceSpawned >= spawnRate) {
			timeSinceSpawned = 0;
			float spawnYPos = Random.Range (pipeMin, pipeMax);
			pipes [currentPipe].transform.position = new Vector2 (spawnXPos, spawnYPos);
			currentPipe++;

			if (currentPipe >= pipePoolSize) {
			
				currentPipe = 0;
			}
		}
	}
}
