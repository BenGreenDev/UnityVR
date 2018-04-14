using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSpawnController : MonoBehaviour {

	public GameObject goalPrefab;
	[SerializeField]
	float radius = 0.0f;

	[SerializeField]
	int objectivesReached = 0;

	[SerializeField]
	RaycastHit hit;

	[SerializeField]
	float delay;
	float timer;
	bool triggerOnce;

	// Use this for initialization
	void Start () {
		timer = 0.0f;
		triggerOnce = false;
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= delay && triggerOnce == false)
		{
			triggerOnce = true;
			goalAchieved (0);
		}
	}

	public void goalAchieved(int obstaclesHitOnWay)
	{
		var randomRotation = Quaternion.Euler (0, Random.Range (0, 360), 0);
		transform.rotation = randomRotation;

		Vector3 raycastSourcePoint = transform.forward * radius;
		bool newSpawnFound = false;

		while (!newSpawnFound) 
		{
			if (Physics.Raycast (raycastSourcePoint, Vector3.down, out hit)) 
			{
				if (hit.transform.gameObject.tag == "Floor")
				{
					GameObject new_instance = Instantiate (goalPrefab);
					new_instance.transform.position = hit.point;
					new_instance.transform.rotation = Quaternion.identity;
					//TODO output the number of obstacles hit along the way!
					newSpawnFound = true;
				}			
			} 
		}
	}
}
