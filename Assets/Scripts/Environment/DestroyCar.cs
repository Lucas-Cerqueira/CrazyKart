using UnityEngine;
using System.Collections;

public class DestroyCar : MonoBehaviour {

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Car")
			Destroy (collision.gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
