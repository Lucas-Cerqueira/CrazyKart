using UnityEngine;
using System.Collections;

public class KartMovement : MonoBehaviour {

	private float accelerometerUpdateInterval = 1.0f / 60.0f;
	private float lowPassKernelWidthInSeconds = 1.0f;

	private float lowPassFilterFactor;
	Vector3 lowPassValue = Vector3.zero;

	private Vector3 tilt = Vector3.zero;
	public float modifier = 5f;
	public float forwardVelocity = 10.0f;
	public float sideVelocity = 10.0f;
	public float sideVelocityTouch = 10.0f;
	public float velocityPC = 10.0f;

	public static bool useAccelerometer = true;



	private void LowPassFilterAccelerometer ()
	{
		lowPassValue = Vector3.Lerp (lowPassValue, Input.acceleration, lowPassFilterFactor);
	}

	// Use this for initialization
	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		#if UNITY_ANDROID
			rigidbody.velocity = Vector3.forward * forwardVelocity;
			lowPassFilterFactor = (accelerometerUpdateInterval / lowPassKernelWidthInSeconds) * modifier;
			lowPassValue = Input.acceleration;
		#endif
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		#if UNITY_ANDROID
			if (Application.isMobilePlatform)                //Check if it's running on cellphone, so this part won't be executed during Unity Editor play
			{	
				if (useAccelerometer)
				{
					LowPassFilterAccelerometer ();
					tilt.x = lowPassValue.x;
					//tilt.z = lowPassValue.y;
					
					rigidbody.velocity = (tilt * sideVelocity + Vector3.forward * forwardVelocity);
				}
				else
				{
					if (Input.touchCount > 0)
					{
						print (Input.touchCount);

						if (((Input.GetTouch (0).position.x < Screen.width/2) && (Input.GetTouch (0).phase != TouchPhase.Ended)))
							rigidbody.velocity = Vector3.left * sideVelocityTouch + Vector3.forward * forwardVelocity;

						if (((Input.GetTouch (0).position.x > Screen.width/2) && (Input.GetTouch (0).phase != TouchPhase.Ended))) 
							//rigidbody.velocity = Vector3.Lerp (rigidbody.velocity, Vector3.right * sideVelocityTouch + Vector3.forward * forwardVelocity, 0.1f);
							rigidbody.velocity = Vector3.right * sideVelocityTouch + Vector3.forward * forwardVelocity;
					}
					else
						rigidbody.velocity = Vector3.forward * forwardVelocity;
				}
			}
		#endif

		#if UNITY_EDITOR_WIN
			Vector3 sideMovement = Input.GetAxis ("Horizontal") * Vector3.right;
			
			rigidbody.velocity = (sideMovement + Vector3.forward) * velocityPC;
		#endif
	}
}
