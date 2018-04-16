﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollider : MonoBehaviour {

    public GameObject lasthit;
    public int number_of_obstacles_hit = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject == lasthit && col.gameObject.tag != "Floor")
        {
            //Do nothing
        }
        else
        {
            lasthit = col.gameObject;
            number_of_obstacles_hit++;
        }
    }

    public int getNumObstaclesHit()
    {
        return number_of_obstacles_hit;
    }

    public void reset()
    {
        number_of_obstacles_hit = 0;
    }
}
