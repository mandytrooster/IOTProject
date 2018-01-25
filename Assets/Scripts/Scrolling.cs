using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Scrolling : MonoBehaviour {

	private Rigidbody2D rb;
	private int speed = 4;
	public static bool stopScrolling = false;
	public int tempInt;
//	public int scroll = 4; //sets initial scroll speed to 0

	SerialPort serial = new SerialPort("/dev/cu.usbmodem1421", 9600);

	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2 (-speed, 0);

		if (!serial.IsOpen) {
			serial.Open ();
		}
		serial.ReadTimeout = 1;

		// Parsed de waarde van seriele verbinding naar de integer speed. Lukt dit niet -> default gravity 
		System.Int32.TryParse(serial.ReadLine(), out tempInt);
		speed = tempInt;

	}

	// Update is called once per frame
	void Update () 
	{
		if (stopScrolling) {
			rb.velocity = Vector2.zero;
		}  else {
			rb.velocity = new Vector2 (-speed, 0);
		} 


		 try {
			System.Int32.TryParse(serial.ReadLine(), out tempInt);

			// als tempInt niet gelijk is aan de huidige waarde van gravity -> verander de gravity naar de nieuwe waarde.
			//if (!(speed == tempInt)) {
				speed = tempInt;
			//}
		}
		catch(System.TimeoutException) {} 
		Debug.Log (speed); 

	}
}

