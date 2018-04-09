using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOn : MonoBehaviour {

	//Overide in prefab to effect all instances
	public float maxIntensity = 2.0f;
	public float reduction = 1.0f;

	private Light thisLight;
    Color activated_color;

    public bool activated = false;

	void Start()
	{
        activated_color = Color.green;

		thisLight = GetComponent<Light> ();
		thisLight.color = GetComponent<MeshRenderer> ().material.color;
		thisLight.intensity = 0.0f;
	}

	// Update is called once per frame
	void Update () 
	{
		if (thisLight.intensity > 0.0f) 
		{
			thisLight.intensity -= reduction * Time.deltaTime;
		}
		else if (thisLight.intensity <= 0.0f) 
		{
			thisLight.intensity = 0.0f;
		}
	}

	public void hitTriggered()
	{
		thisLight.intensity = maxIntensity;
        thisLight.color = activated_color;
        activated = true;
	}

    public bool isActived()
    {
        return activated;
    }
}
