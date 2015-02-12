using UnityEngine;
using System.Collections;

public class DontMoveX : MonoBehaviour {

	private float initialXPosition;

	// Use this for initialization
	void Start () {
		initialXPosition = transform.position.x;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3 (initialXPosition, transform.position.y, transform.position.z);
	}
}
