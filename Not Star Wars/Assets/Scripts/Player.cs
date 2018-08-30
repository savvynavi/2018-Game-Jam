using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour {

	CharacterController controller = null;
	Rigidbody rb = null;
	Vector3 moveDir = Vector3.zero;
	BoxCollider collider = null;
	float lastShot = 0;
	Vector3 force = Vector3.zero;

	public int currHP;
    public int maxHP;
    public float moveSpeed;
	public float rotationSpeed;
	public Transform bullet;
	public float bulletTimer;
    public AudioClip explosionSound;
    public GameObject loseScreen;
    bool exploded = false;
    public int planetsCaptured = 0;
    public int planetsToCapture = 1;
    AudioSource audio;

	public Image casing;
	public Thumbstick stickR;
	public Button shootBtn;


	void Start () {
        currHP = maxHP;
        controller = GetComponent<CharacterController>();
		//rb = GetComponent<Rigidbody>();
		collider = GetComponent<BoxCollider>();
        audio = GetComponent<AudioSource>();
        audio.enabled = false;
	}
	

	void Update () {
		//if dead, does nothing rn just destrpys player object
		if(currHP <= 0){
#if UNITY_ANDROID
			casing.GetComponent<AndroidOnlyUI>().DeactivateButtons();
			shootBtn.GetComponent<AndroidOnlyUI>().DeactivateButtons();
#endif

			audio.enabled = true;
            audio.clip = explosionSound;
            if (!exploded)
            {
                audio.loop = false;
                audio.Play();
                exploded = true;
            }
			GetComponentInChildren<MeshRenderer>().enabled = false;
            Time.timeScale = 0;
			loseScreen.SetActive(true);
		}

        if (planetsCaptured == planetsToCapture)
        {
            gameObject.GetComponent<ScoreTimer>().WinState();
        }

#if UNITY_ANDROID
		//thumbstick movement
		float Vertical = stickR.yAxis;
		float Turn = stickR.xAxis;
		transform.Rotate(Vector3.forward * -Turn * rotationSpeed);

		//Vector3 fwd = (new Vector3(Vertical, Turn, 0)) - (transform.position);
		//float angle = Mathf.Atan2(fwd.x, fwd.z) * Mathf.Rad2Deg;
		//Vector3 angles = transform.eulerAngles;
		//angles.y = Mathf.MoveTowardsAngle(angles.y, angle, rotationSpeed * Time.deltaTime);
		//transform.eulerAngles = angles;

#else
		//pc movement



		float Vertical = Input.GetAxis("Vertical");
		float Turn = Input.GetAxis("Horizontal");
		transform.Rotate(Vector3.forward * -Turn * rotationSpeed);

#endif

		//Movement and rotation values of ship set in moveDir
		moveDir = new Vector3(0, Vertical, 0);
		moveDir = transform.TransformDirection(moveDir);
		moveDir *= moveSpeed;

		if(Vertical != 0 || Turn != 0)
        {
            audio.enabled = true;
        }
        else if (Vertical == 0 && Turn == 0 && currHP > 0)
        {
            audio.enabled = false;
        }

		//rigidbody movement
		//force = transform.up * Vertical * moveSpeed;
		//transform.Rotate(0, 0, -Turn * rotationSpeed);
		//rb.AddForce(force);
		if(Input.GetKey(KeyCode.Space)) {
			Shooting();
		}

	}

	public void Shooting(){
		//shooting
		if(Time.time - lastShot > bulletTimer) {
			lastShot = Time.time;
			Instantiate(bullet, transform.position + (transform.up * (collider.size.y / 2)) + (transform.right * (collider.size.x / 4)), transform.rotation);
			Instantiate(bullet, transform.position + (transform.up * (collider.size.y / 2)) + (transform.right * -1 * (collider.size.x / 4)), transform.rotation);
		}
	}

	void ClampVelocity(){

	}

	void FixedUpdate(){
		//Ship movement
		controller.Move(moveDir * Time.deltaTime);

		//rigidbody movement
	}
}
