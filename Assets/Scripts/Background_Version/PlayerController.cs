using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using UnityEngine.Analytics;

public class PlayerController : MonoBehaviour {

	public static bool isDead = false;
	private Rigidbody2D rb;
	private Animator anim;
	private float up = 0.03f;

	SerialPort serial = new SerialPort("/dev/cu.usbmodem1421", 9600);
	public static bool buttonPressed;
	Thread myThread;
	private string serialInput;
	private bool threadRunning;

	public static int speedValue;
	public static int buttonValue;

	public GameController gameControl;

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
			if (GameController.gameOver == true) {
				closeThread();
			}
		}
	}

	void Update () {
		if (isDead == false) 
		{
			if (Input.GetMouseButtonDown (0))
			{
				rb.velocity = Vector2.zero;
				rb.AddForce (new Vector2 (0, up));
			} 
		}

		if (serialInput != null) {

			string potentiometer = serialInput;

			string[] array = potentiometer.Split (',');
		    speedValue = int.Parse (array [0]);
		    buttonValue = int.Parse (array [1]);

			if (buttonValue == 0) {
				buttonPressed = false;
			} else if (buttonValue == 1) {
				buttonPressed = true;
			} 
		}
	}
		
		void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ground")
			anim.enabled = false;
			GameController.gameOver = true;
			OnGameOver ();
		}
		public void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "Pipe")
			{
				gameControl.Scored ();
			}
		}

		public void OnGameOver()
		{
			Analytics.CustomEvent("gameOver");
		}
		
}
