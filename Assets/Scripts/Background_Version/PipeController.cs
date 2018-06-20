using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour {

	public GameObject pipe;
	private float pipeMin = -1;
	private float pipeMax = -5;
	private float timer;

	void Start(){
		timer = 2;
	}

	void Update(){
		timer -= Time.deltaTime;

		if (timer <= 0 && GameController.gameOver == false) {
			pipeSpeed ();
			spawnPipe ();
		}
	}

	void pipeSpeed (){

		//background speed = 0,4 so to make it around number it's multiplied by 10
		int speed = (int)(BackGroundScrolling.backgroundSpeed * 10);

		switch (speed) {
		case 4:
			timer = 1.5f;
			break;
		case 3:
			timer = 2;
			break;
		case 2:
			timer = 3;
			break;
		case 1:
			timer = 8;
			break;
		}
	}

	void spawnPipe(){		
		float spawnYPosition = Random.Range (pipeMin, pipeMax);

		//the spawnXPosition is 9 so that the pipe will be spawned outside of the screen
		float spawnXPosition = 9;
	    Vector2 randomPos = new Vector2(spawnXPosition, spawnYPosition);
		Instantiate (pipe, randomPos, Quaternion.identity);
	}
}
