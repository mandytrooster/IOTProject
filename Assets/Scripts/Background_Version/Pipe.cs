using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

	private float pipeSpeed;
	private float endPos = -10;

	void Update () {
		//makes the pipes that spawn move towards the player
		if (GameController.gameOver == false && PlayerController.gamePaused == false) {
			pipeSpeed = (float)PlayerController.speedValue;
			transform.Translate(Vector3.left * pipeSpeed * Time.deltaTime);
			//destroy the pipe once it is outside of the screen
			if(transform.position.x <= endPos){
				Destroy(this.gameObject);
			}
		}
	}
}
