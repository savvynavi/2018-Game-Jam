using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyFloaty : MonoBehaviour{
	Rigidbody rb = null;
	Vector3 moveDir = Vector3.zero;
	BoxCollider collider = null;
	float lastShot = 0;
	Vector3 force = Vector3.zero;

	public Transform target;
	public Transform bullet;
	public float speed;
	public float hp;
	public float stopDistance;
	public float bulletTimer;
	public float shootDist;

	// Use this for initialization
	void Start(){
		rb = GetComponent<Rigidbody>();
		collider = GetComponentInChildren<BoxCollider>();
	}

	// Update is called once per frame
	void Update(){
		//if dead, it is destroyed, add explosion here if provided
		if(hp <= 0)	{
			Destroy(transform.gameObject);
		}
		//shooting at player when within range
		float dist = Vector3.Distance(target.transform.position, transform.position);
		if(Time.time - lastShot > bulletTimer && dist <= shootDist){
			lastShot = Time.time;
			var tmpBullet = Instantiate(bullet, transform.position + (transform.forward * collider.size.y), transform.rotation);
		}
	}

	void ClampVelocity(){
		float x = Mathf.Clamp(rb.velocity.x, -speed, speed);
		float y = Mathf.Clamp(rb.velocity.y, -speed, speed);

		rb.velocity = new Vector3(x, y, 0);
	}

	void FixedUpdate(){
		//will move towards the target until the distance between them is smaller than given stopping distance
		float dist = Vector3.Distance(target.position, transform.position);
		//if(dist >= stopDistance && moveDir != Vector3.zero){
		//sets movement up
		moveDir = target.transform.position - transform.position;
		moveDir *= speed;
		//transform.LookAt(target);

		//moveDir = transform.InverseTransformPoint(target.transform.position);

		//rb.AddForce(force * speed);
		//}


		Quaternion newRotation = Quaternion.LookRotation(moveDir * Time.deltaTime);
		float angleDiff = Vector3.Angle(transform.forward, moveDir);
		Vector3 cross = Vector3.Cross(transform.forward, moveDir);
		rb.AddTorque(cross * angleDiff , ForceMode.Force);
		//ClampVelocity();
	}
}
