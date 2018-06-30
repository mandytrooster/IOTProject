﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour {

	public GameObject pipe;
	private float pipeMin = -1;
	private float pipeMax = -5;
	private float pipeTimer;

	void Start(){
		//set timer to 2 so that only one pipe spawns for the first pipe
		pipeTimer = 2;
	}

	void Update(){

		if (PlayerController.gamePaused == false) {
			pipeTimer -= Time.deltaTime;
		}

		if (pipeTimer <= 0 && GameController.gameOver == false && PlayerController.gamePaused == false) {
			pipeSpeed ();
			spawnPipe ();
		}
	}

	void pipeSpeed (){

		//background speed = 0,4 so to make it a round number it's multiplied by 10
		int speed = (int)(BackGroundScrolling.backgroundSpeed * 10);

		switch (speed) {
		case 4:
			pipeTimer = 1.5f;
			break;
		case 3:
			pipeTimer = 2;
			break;
		case 2:
			pipeTimer = 3;
			break;
		case 1:
			pipeTimer = 8;
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
