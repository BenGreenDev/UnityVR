using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour {


	public void hitTriggered()
	{
		Debug.Log("you hit somethin");
		//trigger play particle
		GetComponent<ParticleSystem>().Play();

		// Trigger light instance?
		Debug.Log ("Tried to spawn light");
		GetComponent<LightOn> ().hitTriggered ();

		// Trigger emissive-ness-ness?
	}
}
