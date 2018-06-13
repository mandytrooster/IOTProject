using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmitter : MonoBehaviour {

	public GameObject bulletPrefab;
	public Transform bulletEmitter;

	public float speed = 1000.0f;

	void Update () {
		if (Test.buttonPressed == true) {
			Instantiate (bulletPrefab, bulletEmitter.position, bulletEmitter.rotation);
		}
		Debug.Log ("button pressed: " + Test.buttonPressed);
	}

/*	void Fire(){
		GameObject bulletInstance;
		bulletInstance = Instantiate (bulletPrefab, bulletEmitter.position, bulletEmitter.rotation) as GameObject;

		bulletInstance.transform = new Vector3(0, 0,speed);

	} */
}
