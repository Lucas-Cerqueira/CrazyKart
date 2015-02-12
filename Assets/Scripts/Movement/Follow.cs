using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	public Transform target;

	private float initialXPosition;
	private Vector3 relativePosition;

	// Use this for initialization
	void Start () {
		initialXPosition = transform.position.x;
		relativePosition = target.InverseTransformPoint (transform.position);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3 (initialXPosition, target.position.y + relativePosition.y, target.position.z + relativePosition.z);
	}
}
