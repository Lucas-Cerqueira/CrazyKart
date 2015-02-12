using UnityEngine;
using System.Collections;

public class Overtake : MonoBehaviour {

	void OnTriggerEnter (Collider collider)
	{
		if (collider.tag == "Kart")
			OvertakeCounter.counter++;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
