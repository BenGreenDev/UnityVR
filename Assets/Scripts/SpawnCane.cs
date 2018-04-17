using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SpawnCane : MonoBehaviour {

	public SteamVR_TrackedObject trackedObject = null;
	public SteamVR_Controller.Device device;
	public GameObject canePrefab;
    public GameObject head;
	private bool caneSpawned = false;
    public float cane_length_in_heads = 6.5f;
    public float heads_in_height_ratio = 7.0f;

    public float distance_from_floor = 1.0f;
    public float cane_length = 0.8f;

	// Use this for initialization
	void Start () {
		trackedObject = GetComponent<SteamVR_TrackedObject> ();
        head = GameObject.FindGameObjectWithTag("MainCamera");
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
                RaycastHit hit;

                Ray downRay = new Ray(head.transform.position, -Vector3.up);
                if (Physics.Raycast(downRay, out hit))
                {
                    if (hit.transform.gameObject.tag == "Floor")
                    {
                        distance_from_floor = hit.distance;
                        cane_length = (distance_from_floor / heads_in_height_ratio) * cane_length_in_heads;
                    }
                }

                    Debug.Log ("Tried to spawn it");
				Debug.Log ("Trigger depressed and Grip pressed");

				GameObject newCane = Instantiate (canePrefab, transform.position, Quaternion.identity);
                newCane.transform.localScale = new Vector3(newCane.transform.localScale.x, cane_length, newCane.transform.localScale.z);
                newCane.transform.position = transform.position;
				newCane.transform.parent = gameObject.transform;
				newCane.transform.localPosition = Vector3.zero;
				//.6 z -.1 y

				Quaternion rot = Quaternion.Euler(90,0,0);
				newCane.transform.localRotation = rot;

                Vector3 locTrans = new Vector3(0.0f, -0.03f, cane_length - 0.1f);
                newCane.transform.localPosition = locTrans;
                newCane.transform.tag = "Cane";

				caneSpawned = true;
			}
				

		}

	}
}
