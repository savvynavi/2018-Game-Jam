using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerFloaty : MonoBehaviour{

	Rigidbody rb = null;
	Vector3 moveDir = Vector3.zero;
	BoxCollider collider = null;
	float lastShot = 0;
	Vector3 force = Vector3.zero;

	public float hp;
	public float moveSpeed;
	public float rotationSpeed;
	public Transform bullet;
	public float bulletTimer;

	void Start(){
		rb = GetComponent<Rigidbody>();
		collider = GetComponent<BoxCollider>();
	}


	void Update(){
		//if dead, does nothing rn just destrpys player object
		if(hp <= 0){
			Destroy(transform.gameObject);
		}

		float Vertical = Input.GetAxis("Vertical");
		float Turn = Input.GetAxis("Horizontal");
		force = transform.up * Vertical * moveSpeed;
		transform.Rotate(0, 0, -Turn * rotationSpeed);

		Debug.Log(rb.velocity);

		//shooting
		if(Input.GetKey(KeyCode.Space) && Time.time - lastShot > bulletTimer){
			lastShot = Time.time;
			Instantiate(bullet, transform.position + (transform.up * (collider.size.y)), transform.rotation);
		}
	}

	void ClampVelocity(){
		float x = Mathf.Clamp(rb.velocity.x, -moveSpeed, moveSpeed);
		float y = Mathf.Clamp(rb.velocity.y, -moveSpeed, moveSpeed);

		rb.velocity = new Vector3(x, y, 0);
	}

	void FixedUpdate(){
		rb.AddForce(force);
		ClampVelocity();
	}
}
