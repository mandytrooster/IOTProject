using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour {

//	public GameObject pipes;
//	public float pipeMin = -1;
//	public float pipeMax = 3;
//	private Vector2 pipePosition = new Vector2 (9,-3);
//	private float timer;
//
//	void Start(){
//		timer = 2;
//	}
//
//	void Update(){
//	
//		timer -= Time.deltaTime;
//		Debug.Log (timer);
//
//		if (timer <= 0) {
//			float spawnXPosition = Random.Range (pipeMin, pipeMax);
//			float spawnYPosition = Random.Range (pipeMin, pipeMax);
//
//			Vector2 randomPos = new Vector2(spawnXPosition, spawnYPosition);
//			Instantiate (pipes, randomPos, Quaternion.identity);
//			timer = 2;
//		}
//
////		//TODO FIX THE TIMER SO THAT THE DISTANCE IS BIGGER WITH SLOWER SPEED
////		if (timer >= BackGroundScrolling.backgroundSpeed) {
////			timer = 2;
////			float spawnYPosition = Random.Range (pipeMin, pipeMax);
////			Instantiate (pipes, pipePosition, Quaternion.identity);
////		}
//	}
	public GameObject columnPrefab;                                 
	public int columnPoolSize = 5;                                 
	public float spawnRate = 3f;                                    
	public float columnMin = 50f;                                   
	public float columnMax = 80f;                                 

	private GameObject[] columns;                                  
	private int currentColumn = 0;                                  

	private Vector2 objectPoolPosition = new Vector2 (-15,3);  
	private float spawnXPosition = 10f;

	private float timeSinceLastSpawned;


	void Start()
	{
		timeSinceLastSpawned = 0f;
		columns = new GameObject[columnPoolSize];

		for(int i = 0; i < columnPoolSize; i++)
		{
			//create the columns
			columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
		}
	}


	//This spawns columns as long as the game is not over.
	void Update()
	{
		
		timeSinceLastSpawned += Time.deltaTime;

		if (GameController.gameOver == false && timeSinceLastSpawned >= spawnRate) 
		{   
			timeSinceLastSpawned = 0f;
			float spawnYPosition = Random.Range(columnMin, columnMax);

			//spawn the colomn at the random position
			columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);

			currentColumn ++;

			//If the value of the currentColumn is bigger than the size of the pool, set it to 0
			if (currentColumn >= columnPoolSize) 
			{
				currentColumn = 0;
			}
		}
	}
}
