using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;


public class BGScroll : MonoBehaviour {
/*
	Vector2 startPos;
	int scrollSpeed;
	int tempInt;
	int parseValue;
	public static bool stopScrolling = false;
	Thread myThread;
	string serialInput;


	SerialPort serial = new SerialPort("/dev/cu.usbmodem1421", 9600);

	void Start () {
		startPos = new Vector2(24,0);
		scrollSpeed = 2;
		if (!serial.IsOpen) {
			serial.Open ();
		}
		myThread = new Thread(new ThreadStart(GetArduino));
		myThread.Start();
	}

	private void GetArduino(){

		while(myThread.IsAlive)
		{
			serialInput = serial.ReadLine();
		}
	}

	void Update () {

		transform.Translate ((new Vector2 (-1, 0)) * scrollSpeed * Time.deltaTime);	

		if(transform.position.x < -22){

			transform.position = startPos;
		} 

		if (serialInput != null) {
			System.Int32.TryParse (serialInput, out tempInt);
			if (tempInt != 0 && tempInt < 10) {
				scrollSpeed = tempInt;
			}
		}
		Debug.Log (scrollSpeed);

	} */
}