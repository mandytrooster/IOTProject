using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Test : MonoBehaviour {

	SerialPort serial = new SerialPort("/dev/cu.usbmodem1421", 9600);
	public static bool buttonPressed;

	void Update () {

		if (!serial.IsOpen) {
			serial.Open ();
		}
			
		string rotation = (serial.ReadLine ());

		string[] array = rotation.Split(',');
		int rotationValue = int.Parse(array[0]);
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
	