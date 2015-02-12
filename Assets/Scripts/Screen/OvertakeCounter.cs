using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OvertakeCounter : MonoBehaviour {
	
	public static int counter;

	// Use this for initialization
	void Start () {
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape))
			Application.Quit ();

		GetComponent <Text> ().text = "Overtakes: " + counter.ToString ();
	}
}
