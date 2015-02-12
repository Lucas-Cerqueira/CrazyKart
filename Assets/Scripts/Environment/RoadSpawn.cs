using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoadSpawn : MonoBehaviour {

	public Transform kart;
	public GameObject roadPrefab;

	private List <Transform> roadBlocks = new List <Transform> ();

	private int currentRoadBlock = 0;

	// Use this for initialization
	void Start () {
		Transform [] auxRoadBlocks = GetComponentsInChildren <Transform> ();     //Getting the roadBlocks

		foreach (Transform road in auxRoadBlocks)		//Adding them to a list
			if (road != transform)
				roadBlocks.Add (road);
	}
	
	// Update is called once per frame
	void Update () {


		/*	Checking in which road block the car is. 
			I'm getting the center of the block and adding half of its size to get the edge position*/
		if (kart.position.z >= roadBlocks [currentRoadBlock].position.z + roadBlocks [currentRoadBlock].renderer.bounds.size.z/2)
		{
			currentRoadBlock++;

			if (currentRoadBlock > 1)
			{
				roadBlocks.Remove (roadBlocks [currentRoadBlock - 2]);
				Destroy (transform.GetChild (currentRoadBlock - 2).gameObject);
				currentRoadBlock--;


				Vector3 newRoadPosition = roadBlocks [roadBlocks.Count-1].position + new Vector3 (0,0,roadBlocks [roadBlocks.Count-1].renderer.bounds.size.z);
				GameObject newRoad = Instantiate (roadPrefab, newRoadPosition, roadBlocks [0].rotation) as GameObject;
				newRoad.transform.parent = transform;
				newRoad.transform.localScale = roadBlocks [0].localScale;
				roadBlocks.Add (newRoad.transform);
			}


		}
	}
}

