using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScrolling : MonoBehaviour {


	private float speed;

	void Start () {
	
		speed = 1;
	}
		
	// Update is called once per frame
	void Update () {

		Vector2 bgScroll = new Vector2 (Time.time * PlayerController.rotationValue, 0);
		GetComponent<Renderer>().material.mainTextureOffset = bgScroll;﻿

		Debug.Log (PlayerController.rotationValue);
	}
}
