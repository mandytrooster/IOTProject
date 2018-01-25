using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class BGScroll : MonoBehaviour {

	Vector2 startPos;
	int scrollSpeed;
	int tempInt;
	public static bool stopScrolling = false;

	SerialPort serial = new SerialPort("/dev/cu.usbmodem1421", 9600);

	void Start () {
		startPos = new Vector2(24,0);
		scrollSpeed = 2;

		if (!serial.IsOpen) {
			serial.Open ();
		}
		serial.ReadTimeout = 200;
		System.Int32.TryParse(serial.ReadLine(), out tempInt);
		scrollSpeed = tempInt;
	}

	void Update () {

		transform.Translate ((new Vector2 (-1, 0)) * scrollSpeed * Time.deltaTime);	

		if(transform.position.x < -22){

			transform.position = startPos;
		} 
			

		try {
			System.Int32.TryParse(serial.ReadLine(), out scrollSpeed);

			// als tempInt niet gelijk is aan de huidige waarde van gravity -> verander de gravity naar de nieuwe waarde.
			//if (!(scrollSpeed == tempInt)) {
			//	scrollSpeed = tempInt;
				Debug.Log("nieuwe snelheid: " + scrollSpeed);
			//}
		}
		catch(System.TimeoutException) {} 
		//Debug.Log(scrollSpeed); 
	}
}