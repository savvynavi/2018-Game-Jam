using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
	public Transform player;
	public float distanceFromPlayer;

	// Update is called once per frame
	void Update () {
		if(player != null){
			transform.position = new Vector3(player.position.x, player.position.y, player.position.z - distanceFromPlayer);
		}
	}
}
