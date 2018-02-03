using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

	private Rigidbody2D rb;
	Vector2 startPos;
	int scrollSpeed;


	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		startPos = new Vector2(24,0);
		scrollSpeed = 2;
			
	}

	void Update () {

		if (GameController.instance.gameOver == true) {
			rb.velocity = Vector2.zero;
		} else {
		transform.Translate ((new Vector2 (-1, 0)) * scrollSpeed * Time.deltaTime);
		}
		if(transform.position.x < -22){

			transform.position = startPos;
		} 
	}
}
