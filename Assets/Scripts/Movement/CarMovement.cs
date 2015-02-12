using UnityEngine;
using System.Collections;

public class CarMovement : MonoBehaviour {

	private float kartVelocity;
	private float carVelocity;
	private float minVelocity;
	private float maxVelocity;

	// Use this for initialization
	void Start () {
		#if UNITY_EDITOR_WIN
			kartVelocity = GameObject.Find ("Kart").GetComponent <KartMovement> ().velocityPC;
		#endif

		#if UNITY_ANDROID
			if (Application.isMobilePlatform)
				kartVelocity = GameObject.Find ("Kart").GetComponent <KartMovement> ().forwardVelocity;
		#endif

		minVelocity = kartVelocity / 5;
		maxVelocity = kartVelocity - 10;

		carVelocity = Random.Range (minVelocity, maxVelocity);
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.velocity = new Vector3 (0, 0, carVelocity);
	}
}
