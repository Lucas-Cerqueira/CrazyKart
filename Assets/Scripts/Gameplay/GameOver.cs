using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public GameObject GameOverPanel;

	public void Restart ()
	{
		Time.timeScale = 1;
		Application.LoadLevel (0);
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Car")
		{
			Time.timeScale = 0;
			GameOverPanel.SetActive (true);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
