using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Scrolling : MonoBehaviour
{

	private Rigidbody2D rb;
	private int speed = 4;
	public static bool stopScrolling = false;
	public int tempInt;
	//	public int scroll = 4; //sets initial scroll speed to 0
	string serialInput;
	SerialPort serial = new SerialPort("/dev/cu.usbmodem1421", 9600);

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(-speed, 0);

		if (!serial.IsOpen)
		{
			serial.Open();
		}
		serial.ReadTimeout = 1;
		serial.DataReceived += DataReceivedHandler;

		// Parsed de waarde van seriele verbinding naar de integer speed. Lukt dit niet -> default gravity 
		System.Int32.TryParse(serialInput, out speed);
	}

	private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
	{
		SerialPort sp = (SerialPort)sender;
		string serialInput = sp.ReadLine();
		Debug.Log(serialInput);
	}

	// Update is called once per frame
	void Update()
	{
		if (stopScrolling)
		{
			rb.velocity = Vector2.zero;
		}
		else
		{
			rb.velocity = new Vector2(-speed, 0);
		}

		System.Int32.TryParse(serialInput, out speed);
		//Debug.Log(speed);

	}

}



