﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class GoalSpawnController : MonoBehaviour {


	public GameObject[] goals;
	private GameObject activeGoal;
	[SerializeField]
	float radius = 0.0f;

	[SerializeField]
	int objectivesReached = 0;
	int index = 0;
	int maxIndex =0;

	[SerializeField]
	RaycastHit hit;

	[SerializeField]
	float delay;
	float timer;
	bool triggerOnce;

    public string file_name_for_user = "GoalData.txt";

    // Use this for initialization
    void Start () 
	{
		timer = 0.0f;
		triggerOnce = false;
		goals = GameObject.FindGameObjectsWithTag ("Goal");
		activeGoal = goals [0];
		maxIndex = goals.Length - 1;
	}

	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		if (timer >= delay && triggerOnce == false)
		{
			triggerOnce = true;
			goalAchieved (0);
		}
	}

	public void goalAchieved(int obstaclesHitOnWay)
	{
		Debug.Log("Goal: " + objectivesReached + "Reached");
		Debug.Log("Number of obstacles hit on the way: " + obstaclesHitOnWay);
		printToTextFile(obstaclesHitOnWay);

		activeGoal.GetComponent<GoalActivityController> ().setActive (false);
		index++;
		if (index > maxIndex) 
		{
			//TODO - Alternatively, end experience?
			index = 0;
		}
		goals[index].GetComponent<GoalActivityController> ().setActive (true);
	}

    void printToTextFile(int obstaclesHitOnWay)
    {
        if (File.Exists(file_name_for_user))
        {
            var sr = File.CreateText(file_name_for_user);
            sr.WriteLine("Goal: " + objectivesReached + " Reached in: " + timer);
            sr.WriteLine("Number of obstacles hit on the way: " + obstaclesHitOnWay);
            sr.Close();
        }
        else
        {
            Debug.Log("Could not Open the file: " + file_name_for_user + " for reading.");
            return;
        }
    }
}
