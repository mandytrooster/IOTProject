using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour {

	public int pipePoolSize = 5;
	public GameObject pipePrefab;
	public float spawnRate = 4f;
	public float pipeTopMin;
	public float pipeTopMax;

	private Vector2 startPosition = new Vector2 (9f, 3f);
	private GameObject[] pipesTop;
	private float timeSinceSpawned;
	private float spawnXPos = 10f;
	private int currentPipe = 0;

	void Start () {

		pipesTop = new GameObject[pipePoolSize];
		for (int i = 0; i < pipePoolSize; i++) {
			//initiate the first pipe at the pipePosition location
			pipesTop [i] = (GameObject)Instantiate (pipePrefab, startPosition, Quaternion.identity);
		}
	}

	// Update is called once per frame
	void Update () {
		timeSinceSpawned += Time.deltaTime;

		if (GameController.gameOver == false && timeSinceSpawned >= spawnRate) {
			timeSinceSpawned = 0;

			//Gets a random value between the min & maxwhere the pipe spawns on the y axis.
			float spawnYPos = Random.Range (pipeTopMin, pipeTopMax);

			//the x and y position that the pipes get spawned on. 10 to have it out of screen. 
			pipesTop [currentPipe].transform.position = new Vector2 (spawnXPos, spawnYPos);
			currentPipe++;

			if (currentPipe >= pipePoolSize) {

				currentPipe = 0;
			}
		}
	}
}
