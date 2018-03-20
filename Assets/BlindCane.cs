using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindCane : MonoBehaviour {

    public bool isHeld = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag != "Player" && isHeld)
        {

            Debug.Log("you hit somethin");
            //trigger play particle
            if (other.gameObject.GetComponent<ParticleSystem>())
            {
                other.gameObject.GetComponent<ParticleSystem>().Play();
            }

            // Trigger light up


        }

    }

    public void setIsHeld(bool newVal)
    {
        isHeld = newVal;
    }
    //void OnCollisionStay(Collision other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        isHeld = true;
    //     //   GetComponent<Rigidbody>().isKinematic = true;
    //        return;
    //    }
    //    else
    //    {
    //        isHeld = false;
    //      //  GetComponent<Rigidbody>().isKinematic = false;
    //        return;
    //    }
    //}
}
