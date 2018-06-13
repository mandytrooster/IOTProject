using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

//	private BoxCollider2D groundCollider;
	private float length;

	void Start () {
	//	groundCollider = GetComponent<BoxCollider2D> ();
		//length = 21.4f;
		length = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -length) {
			moveBackground ();
		}
	}

	private void moveBackground()
	{
		Vector2 offset = new Vector2 (length * 2f, 0);
		transform.position = (Vector2)transform.position + offset;
	}
}
