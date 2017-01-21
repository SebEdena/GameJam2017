﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour {

	private Deplacement dep;
	public float coefBoostSpeed;
	public float timerBoostSpeed;
	public float timerImmunity;
	private float startTime = 0.0f;
	private bool isInvincible;

	private float baseSpeed;
	private float baseRotation;

	// Use this for initialization
	void Start () {
		dep = GetComponentInParent<Deplacement> ();
		baseSpeed = dep.vMax;
		baseRotation = dep.vRotate;
	}

	void Update () {

	}

    /*private void OnCollisionEnter(Collision other)
    {
        Debug.Log("done");
        if (other.gameObject.CompareTag("Player"))
            other.gameObject.GetComponentInParent<Player>().die();
        else
            GetComponentInParent<Player>().die();
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            other.gameObject.GetComponentInParent<Player>().die();
        else if (other.gameObject.CompareTag("Front"))
            GetComponentInParent<Player>().derive(other.gameObject);
        else if (other.gameObject.CompareTag("Wall"))
        {
            GetComponentInParent<Player>().die();
            //transform.parent.forward *= -1;
        }
		else if(other.gameObject.CompareTag("Collectible")){
			if (other.name == "collectibleVitesse") {
				Destroy(other.gameObject);
				dep.vMax = dep.vMax * coefBoostSpeed;
				dep.vRotate = dep.vRotate * coefBoostSpeed;
				Invoke ("SpeedTimer", timerBoostSpeed);
			}
			else if (other.name == "collectibleInvincible") {
				Destroy (other.gameObject);
				isInvincible = true;
				Invoke ("ImmunityTimer", timerImmunity);
			}
		}
        else
            GetComponentInParent<Player>().die();
    }

	public bool getInvincible(){
		return isInvincible;
	}

	void SpeedTimer()
	{
		dep.vMax = baseSpeed;
		dep.vRotate = baseRotation;
	}

	void ImmunityTimer()
	{
		isInvincible = false;
	}
}
