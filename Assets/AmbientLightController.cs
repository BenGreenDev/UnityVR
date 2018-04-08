using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientLightController : MonoBehaviour {

	public enum LightState
	{
		FULL_LIGHT = 0,
		HALF_LIGHT,
		NO_LIGHT
	};

	public float fullLightDuration = 10.0f;
	public float halfLightDuration = 10.0f;

	public float fadeSlowing = 0.0f;

	public Color ambientColor;
	public Color skyboxColor;
	public Color dimmedColor;
	public Color blackColor;


	public LightState ambienceState;

	private float timer = 0.0f;

	// Use this for initialization
	void Start () {

		ambientColor = RenderSettings.ambientLight;
		skyboxColor = RenderSettings.skybox.color;
		timer = fullLightDuration;
		ambienceState = LightState.FULL_LIGHT;

	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;

		if (timer <= 0.0f && ambienceState == LightState.FULL_LIGHT) 
		{
			if (RenderSettings.ambientIntensity >= 0.5f) 
			{
				RenderSettings.ambientIntensity -= Time.deltaTime * fadeSlowing;
				RenderSettings.reflectionIntensity -= Time.deltaTime* fadeSlowing;
				RenderSettings.ambientLight = Color.Lerp(ambientColor, dimmedColor, 1.5f);
				RenderSettings.skybox.color = Color.Lerp(skyboxColor, dimmedColor, 1.5f);
			} 
			else 
			{
				ambienceState = LightState.HALF_LIGHT;
				ambientColor = dimmedColor;
				skyboxColor = dimmedColor;
				timer = halfLightDuration;
			}
		}
		if (timer <= 0.0f && ambienceState == LightState.HALF_LIGHT) 
		{
			if (RenderSettings.ambientIntensity >= 0.0f) 
			{
				RenderSettings.ambientIntensity -= Time.deltaTime * fadeSlowing;
				RenderSettings.reflectionIntensity -= Time.deltaTime* fadeSlowing;
				RenderSettings.ambientLight = Color.Lerp(ambientColor, blackColor, 1.5f);
				RenderSettings.skybox.color = Color.Lerp(skyboxColor, dimmedColor, 1.5f);
			} 
			else 
			{
				ambienceState = LightState.NO_LIGHT;
				timer = 0.0f;
			}
		}
	}
}
