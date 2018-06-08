using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	public float distance;
	public float minDistance = 20;
	public float maxDistance = 4;
	public Transform player;
	public float speed = 5.0F;
	public Stats stats;
	bool following = false;
	bool subtractFollowing = false;
	void Start(){
		stats = player.GetComponent<Stats> ();
	}

	void FixedUpdate(){
		float step = speed * Time.deltaTime;
		distance = Vector3.Distance (transform.position, player.position);

		if (following == true) {
			if (distance >= minDistance) {
				following = false;
				if (subtractFollowing = true) {
					stats.enemiesFolowing -= 1;
					subtractFollowing = false;
				}
			} else {
				transform.position = Vector3.MoveTowards (transform.position, player.position, step);
			}
		} else {
			if (stats.enemiesFolowing < stats.maxFollowing) {
				if (distance >= maxDistance && distance <= minDistance) {
					if (following == false) {
						following = true;
						stats.enemiesFolowing += 1;
						subtractFollowing = true;
					}

				} else {
					if (following == true) {
						following = false;
						stats.enemiesFolowing -= 1;
					}
				}
			}
		}
	}
}
