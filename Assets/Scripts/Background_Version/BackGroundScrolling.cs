using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScrolling : MonoBehaviour {

	public static float backgroundSpeed;
	public float speed;
	public static float newSpeed;

	void Update () {

		newSpeed= (float)PlayerController.speedValue;
		Vector2 bgScroll = new Vector2 (Time.time * backgroundSpeed, 0);
		GetComponent<Renderer> ().material.mainTextureOffset = bgScroll;﻿
		backgroundSpeed = newSpeed/10;

		if (GameController.gameOver == true) {
			backgroundSpeed = 0;
		}
	}
}
