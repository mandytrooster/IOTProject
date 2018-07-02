 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using UnityEngine.Analytics;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator anim;
	private float up = 0.03f;

	SerialPort serial = new SerialPort("/dev/cu.usbmodem1421", 9600);
	private bool buttonPressed;
	Thread myThread;
	private string serialInput;
	private bool threadRunning;

	public static int speedValue;
	public static int buttonValue;
	public static int secondButtonValue;

	public GameController gameControl;

	public static bool gamePaused;
	private float timer = 5;
	private bool buttonTimer = false;
	private float timebetweenbuttons = 0.2f;

	public Sprite[] sprites;
	private int spriteNumber = 0;
	private bool spriteTimer = false;
	private float timebetweenSprites = 0.3f;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent < Animator> ();

		if (!serial.IsOpen) {	
			//make the game pause untill it is connected
			PauseGame();
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

		if(gamePaused == true){
			timer -= Time.deltaTime;
		}
		if(timer <= 0){
			gamePaused = false;
			rb.isKinematic = false;
		}
			
		if (serialInput != null) {

			string potentiometer = serialInput;

			string[] array = potentiometer.Split (',');
		    speedValue = int.Parse (array [0]);
		    buttonValue = int.Parse (array [1]);
			secondButtonValue = int.Parse (array [2]);

			if (buttonValue == 0) {
				buttonPressed = false;
			} else if (buttonValue == 1 && buttonTimer == false) {
				buttonPressed = true;
			} 
		}

		if (GameController.gameOver == false && gamePaused == false) 
		{
			if (Input.GetMouseButtonDown (0) || buttonPressed == true)
			{
				Jump ();
			} 
		}

		if (secondButtonValue == 1 && spriteTimer == false) {

			//go through the array of sprites and reset it once it's at the 3rd color
			spriteNumber += 1;
			if(spriteNumber >= 3){
				spriteNumber = 0;
			}
			//set the sprite to the current sprite number which is changed by pressing the button
			GetComponent<SpriteRenderer>().sprite = sprites[spriteNumber];

			StartCoroutine (waitForNextSprite ());
			Debug.Log (spriteNumber);	
		}
	}
		
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ground")
			anim.enabled = false;
			GameController.gameOver = true;
	}

	public void OnTriggerEnter2D(Collider2D other){
			
		if (other.tag == "PipeRed" && spriteNumber == 0) {
			gameControl.Scored ();
		} else if (other.tag == "PipeBlue" && spriteNumber == 1) {
			gameControl.Scored ();
		} else if (other.tag == "PipeGreen" && spriteNumber == 2) {
			gameControl.Scored ();
		} else {
			GameController.gameOver = true;
		}
			
	}

	void PauseGame(){
		gamePaused = true;
		rb.isKinematic = true;
	}

	void Jump(){
		rb.velocity = Vector2.zero;
		rb.AddForce (new Vector2 (0, up));
		buttonPressed = false;
		StartCoroutine (waitForNext ());
	}

	IEnumerator waitForNext() {
		buttonTimer = true;
		yield return new WaitForSeconds (timebetweenbuttons);
		buttonTimer = false;
	}
	IEnumerator waitForNextSprite() {
		spriteTimer = true;
		yield return new WaitForSeconds (timebetweenSprites);
		spriteTimer = false;
	}
}
