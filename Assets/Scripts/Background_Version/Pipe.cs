using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

	// Use this for initialization
	private float pipeSpeed;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (GameController.gameOver == false) {
			pipeSpeed = (float)PlayerController.speedValue;
			transform.Translate(Vector3.left * pipeSpeed * Time.deltaTime);
		}
	}
}
