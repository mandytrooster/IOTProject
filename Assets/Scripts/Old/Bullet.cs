using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private float speed = 50; 
	Rigidbody2D rb;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();	
	}


	void Update () {
	//	GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.x);
	//	transform.Translate(Vector3.forward * speed * Time.deltaTime);
		rb.AddForce(transform.right * speed);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
	//	Destroy (gameObject);
	}
}
