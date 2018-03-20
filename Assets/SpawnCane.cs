using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SpawnCane : MonoBehaviour {

	public SteamVR_TrackedObject trackedObject = null;
	public SteamVR_Controller.Device device;
	public GameObject canePrefab;
	private bool caneSpawned = false;

	// Use this for initialization
	void Start () {
		trackedObject = GetComponent<SteamVR_TrackedObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		//pool device
		device = SteamVR_Controller.Input ((int)trackedObject.index);

		if (device.GetTouchDown (SteamVR_Controller.ButtonMask.Trigger)
		//	&& (device.GetPressDown (SteamVR_Controller.ButtonMask.Grip)) 
		)
		{

			if (caneSpawned == false) 
			{
				Debug.Log ("Tried to spawn it");
				Debug.Log ("Trigger depressed and Grip pressed");

				GameObject newCane = Instantiate (canePrefab, transform.position, Quaternion.identity);
				newCane.transform.parent = gameObject.transform;
				newCane.transform.localPosition = Vector3.zero;
				//.6 z -.1 y

				Quaternion rot = Quaternion.Euler(90,0,0);
				newCane.transform.localRotation = rot;

				Vector3 locTrans = new Vector3(0.0f, -0.03f, 0.7f);
				newCane.transform.localPosition = locTrans;
				newCane.transform.tag = "Cane";

				caneSpawned = true;
			}
				

		}

	}
}
