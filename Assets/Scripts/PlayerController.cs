using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class PlayerController : MonoBehaviour {

	public static bool isDead = false;
	private Rigidbody2D rb;
	private Animator anim;
	private float up = 200f;

	SerialPort serial = new SerialPort("/dev/cu.usbmodem1421", 9600);
	public static bool buttonPressed;
	Thread myThread;
	string serialInput;
	bool threadRunning;


	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent < Animator> ();

		if (!serial.IsOpen) {
			serial.Open ();
		} 
		threadRunning = true;
		myThread = new Thread(new ThreadStart(GetArduino));
		myThread.Start();
	}

	private void closeThread() {
		threadRunning = false;
		serial.Close();
		Debug.Log("thread is closed");
	}

	private void GetArduino(){

		while (threadRunning) {
			serialInput = serial.ReadLine ();
			Debug.Log ("serial input: " + serialInput);
			if (GameController.instance.gameOver == true) {
				closeThread();
			}
		}
	}

	void Update () {

		//Player Jump -------
		if (Input.GetMouseButtonDown (0)) {
			rb.velocity = Vector2.zero;
			rb.AddForce (new Vector2 (0, up));
			anim.enabled = true;
		} 

		if (serialInput != null) {

			string rotation = serialInput;

			string[] array = rotation.Split (',');
			int rotationValue = int.Parse (array [0]);
			int buttonValue = int.Parse (array [1]);

			transform.localEulerAngles = new Vector3 (0, 0, rotationValue);

			Debug.Log ("rotation: " + rotationValue);
			Debug.Log ("button: " + buttonValue);

			if (buttonValue == 0) {
				buttonPressed = false;
			} else if (buttonValue == 1) {
				buttonPressed = true;
			} 
		}
	}


	void OnCollisionEnter2D(Collision2D other)
	{
		rb.velocity = Vector2.zero;
		isDead = true;
		anim.enabled = false;
		GameController.instance.OnGround ();
	} 
}
