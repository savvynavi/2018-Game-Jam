﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour {

	CharacterController controller = null;
	Rigidbody rb = null;
	Vector3 moveDir = Vector3.zero;
	BoxCollider collider = null;
	float lastShot = 0;
	Vector3 force = Vector3.zero;
	public int currHP;

	public int maxHp;
	public float moveSpeed;
	public float rotationSpeed;
	public Transform bullet;
	public float bulletTimer;

	void Start () {
		currHP = maxHp;
		controller = GetComponent<CharacterController>();
		collider = GetComponent<BoxCollider>();
	}
	

	void Update () {
		//if dead, does nothing rn just destrpys player object
		if(currHP <= 0){
			currHP = 0;
			Destroy(transform.gameObject);
		}

		float Vertical = Input.GetAxis("Vertical");
		float Turn = Input.GetAxis("Horizontal");
		//Movement and rotation values of ship set in moveDir
		moveDir = new Vector3(0, Vertical, 0);
		moveDir = transform.TransformDirection(moveDir);
		moveDir *= moveSpeed;
		transform.Rotate(Vector3.forward * -Turn * rotationSpeed);

		//shooting
		if(Input.GetKey(KeyCode.Space) && Time.time - lastShot > bulletTimer){
			lastShot = Time.time;
			Instantiate(bullet, transform.position + (transform.up * (collider.size.y)), transform.rotation);
		}
	}

	void FixedUpdate(){
		//Ship movement
		controller.Move(moveDir * Time.deltaTime);
	}
}
