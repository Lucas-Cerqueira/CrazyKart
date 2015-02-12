using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AccelerometerToggle : MonoBehaviour {

	private bool valueChangedInternally = false;


	public void useAccelerometerToggle()
	{
		if (!valueChangedInternally)
			KartMovement.useAccelerometer = !KartMovement.useAccelerometer;
	}
	

	// Use this for initialization
	void Start () {
		valueChangedInternally = true;

		if (KartMovement.useAccelerometer)
			GetComponent <Toggle> ().isOn = true;
		else
			GetComponent <Toggle> ().isOn = false;

		valueChangedInternally = false;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
