using UnityEngine;
using System.Collections;

public class GenerateCar : MonoBehaviour {
	
	public GameObject blackCarPrefab;
	public GameObject blueCarPrefab;
	public float spawnChance = 33f;
	public float cooldown = 3f;

	private GameObject[] carPrefabs = new GameObject [2];
	private GameObject selectedCar;
	private float lastTime;


	void Awake () {
		carPrefabs [0] = blackCarPrefab;
		carPrefabs [1] = blueCarPrefab;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if ((Time.time - lastTime) >= cooldown)
		{
			selectedCar = carPrefabs [Random.Range (0, 2)];
			if (Random.value * 100 <= spawnChance)
				Instantiate (selectedCar, transform.position, transform.rotation);
			lastTime = Time.time;
		}

	}
}
