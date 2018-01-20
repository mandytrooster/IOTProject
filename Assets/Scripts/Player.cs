using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Player : MonoBehaviour {
	
	private bool isDead = false;
	private Rigidbody2D rb;
	private Animator anim;
	private float up = 200f;

	/* ----BUTTON---
	SerialPort serial = new SerialPort("/dev/cu.usbmodem1421", 9600);
	public GameObject playerObject;
	public float offX = 6f, offY = 6f, offZ =0.7f;
	public float onX = 10f, onY = 10f, onZ =3; */

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent < Animator> ();

	/*	serial.Open ();
		if (!serial.IsOpen) {
			serial.Open ();
		} */
	}

	void Update () {

		/* ----BUTTON----
		string fromArduino = serial.ReadLine ();
		int dataFromArduino = int.Parse (fromArduino);
		Debug.Log (dataFromArduino);
		changeSize (dataFromArduino); */

		/*---- GRAVITY-----
		 string gravity = serial.ReadLine();
		float g = float.Parse (gravity); 
		rb.gravityScale = (g/10); */

		if (isDead == false) 
		{
			if (Input.GetMouseButtonDown (0))
			{
				rb.velocity = Vector2.zero;
				rb.AddForce (new Vector2 (0, up));
			//	anim.SetTrigger ("Flap");
			}
		}
		//Debug.Log (g);
	}

	void OnCollisionEnter2D()
	{
		rb.velocity = Vector2.zero;
		isDead = true;
		anim.enabled = false;
		GameController.instance.BirdDied ();
	}
}

	/* -----BUTTON-----
	void changeSize(int buttonStatus){
		
		switch (buttonStatus) {
		case 0:
			playerObject.gameObject.transform.localScale = new Vector3 (offX, offY, offZ);
			break;
		case 1:
			playerObject.gameObject.transform.localScale = new Vector3 (onX, onY, onZ);
			break;
		} 
	} */

