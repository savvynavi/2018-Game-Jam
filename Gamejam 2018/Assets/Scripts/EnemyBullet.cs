using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyBullet : MonoBehaviour{
	Vector3 moveDir = Vector3.zero;
	Rigidbody rigidbody;

	public float speed;
	public float aliveTime;
	public int damage;

	// Use this for initialization
	void Awake(){
		rigidbody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate(){
	if(transform.gameObject.layer == 11){
			rigidbody.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
		}
		Destroy(transform.gameObject, aliveTime);
	}

	private void OnCollisionEnter(Collision collision){
		//if it collides with an enemy, it despawns
		Player tmp = collision.gameObject.GetComponent<Player>();
		if(tmp != null && collision.gameObject.layer == 9){
			tmp.currHP -= damage;
			Destroy(transform.gameObject);
		}
	}
}
