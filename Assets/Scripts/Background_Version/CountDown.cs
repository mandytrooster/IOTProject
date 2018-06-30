using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

	public int coountdown = 5;
	public Text countdownText;
	public GameObject countdownObject;

	void Start () {
		StartCoroutine("Timer");
		countdownObject.SetActive (true);
	}

	void Update () {
		countdownText.text = ("" + coountdown);

		if (coountdown <= 0)
		{
			StopCoroutine("Timer");
			countdownObject.SetActive (false);
			
		}
	}

	IEnumerator Timer()
	{
		while (true)
		{
			yield return new WaitForSeconds(1);
			coountdown--;
		}
	}
}
