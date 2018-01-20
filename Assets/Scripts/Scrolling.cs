using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

	public class Scrolling : MonoBehaviour {

	private Rigidbody2D rb;
//	public float scroll;
	public float speed;
	public int tempInt;
	public int scroll = 4; // sets standard gravity to 4. Can be changed later

	SerialPort serial = new SerialPort("/dev/cu.usbmodem1421", 9600);

	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();

		if (!serial.IsOpen) {
			serial.Open ();
		}

		// Parsed de waarde van seriele verbinding naar de integer gravity. Lukt dit niet -> default gravity 
		System.Int32.TryParse(serial.ReadLine(), out scroll);
		speed = scroll;
		tempInt = scroll;
	}

	void Update () 
	{
		rb. velocity = new Vector2 (-scroll, 0);
		//parsed de waarde die gelezen wordt op readline naar tempInt.
		try {
			System.Int32.TryParse(serial.ReadLine(), out tempInt);

			// als tempInt niet gelijk is aan de huidige waarde van gravity -> verander de gravity naar de nieuwe waarde.
			if (!(scroll == tempInt)) {
				scroll = tempInt;
				speed = scroll;
				tempInt = scroll;
			}
		}
		catch(System.TimeoutException) {}
		Debug.Log (scroll);
	}
}
/*
	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();

		if (!serial.IsOpen) {
			serial.Open ();
		}

		string gravity = serial.ReadLine();


		if(!System.String.IsNullOrEmpty(gravity)){
			speed = float.Parse(gravity);
			tempInt = int.Parse(gravity);
		}
	}

	void Update () 
	{

		rb. velocity = new Vector2 (scroll, 0);

		string gravity = serial.ReadLine();
		if (!System.String.IsNullOrEmpty (gravity)) {

			if (int.Parse (gravity) == tempInt) {
				speed = float.Parse (gravity);
				tempInt = int.Parse (gravity);
			}
		}
	}
}

*/