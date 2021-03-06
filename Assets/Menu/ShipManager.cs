﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour {

	public GameObject ShipInMovement;
	public static bool IsClick = false;
	public GameObject ButtonsMenu;
	public GameObject EscapeObj;
	public GameObject ButtonsSelection;

	private Vector3 origin;

	void Start () {
		origin = ShipInMovement.transform.position;
		ButtonsMenu.SetActive (true);
		EscapeObj.SetActive(false);
		ButtonsSelection.SetActive (false);
	}


	void Update () {
		if (!ShipManager.IsClick)
			ShipInMovement.transform.position = 
				new Vector3 (ShipInMovement.transform.position.x, 
				origin.y + Mathf.Cos(Time.time) * 0.5f, ShipInMovement.transform.position.z);
	}
}