using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

	public int HP = 3;
	public int LV = 1;
	public int STA = 0;
	public int ATK = 0;
	public float SPD = 0;
	public float MSPD;
	public string STATE = "null";
	public int Weight = 1;
	public int MaxWeight = 10;
	public int maxFollowing = 4;
	public int enemiesFolowing = 0;
	bool canPickUpItems = true;

	void Start(){
		MSPD = SPD;
	}

	// Update is called once per frame
	void Update () {
		if (Weight >= MaxWeight) {
			canPickUpItems = false;
			SPD = SPD / 2;
		} else {
			SPD = MSPD;
		}
		if (STATE != "null") {

		}
	}
}
