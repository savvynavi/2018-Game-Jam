using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Enemy : MonoBehaviour {
	CharacterController controller = null;
	Vector3 moveDir = Vector3.zero;
	BoxCollider collider = null;
	float lastShot = 0;
	float angleBetween = 0.0f;

	public Transform target;
	public Transform bullet;
	public float speed;
	public float hp;
	public float stopDistance;
    public float maxDist;
	public float bulletTimer;
	public float shootDist;
    bool soundPlaying = false;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		collider = GetComponentInChildren<BoxCollider>();
	}

	// Update is called once per frame
	void Update () {
		//if dead, it is destroyed, add explosion here if provided
		if(hp <= 0){
            Renderer[] rs = GetComponentsInChildren<Renderer>();
            foreach (Renderer ren in rs)
            {
                ren.enabled = false;
            }
            // GetComponentInChildren<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<CharacterController>().enabled = false;
            if (!soundPlaying)
            {
                GetComponent<AudioSource>().Play();
                soundPlaying = true;
            }

			Destroy(transform.gameObject, 2);
		}

		//sets movement up
		moveDir = target.transform.position - transform.position;
		moveDir *= speed;
		transform.LookAt(target);

		//shooting at player when within range
		float dist = Vector3.Distance(target.position, transform.position);
		if(Time.time - lastShot > bulletTimer && dist <= shootDist && (hp > 0))
        {
			lastShot = Time.time;
			var tmpBullet = Instantiate(bullet, transform.position + (transform.forward * collider.size.y), transform.rotation);
		}
	}

	void FixedUpdate(){
		//will move towards the target until the distance between them is smaller than given stopping distance
		float dist = Vector3.Distance(target.position, transform.position);
		if(dist <= maxDist && dist >= stopDistance && moveDir != Vector3.zero){
			controller.Move(moveDir.normalized * speed * Time.deltaTime);
		}
	}
}
