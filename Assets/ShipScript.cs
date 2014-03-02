using UnityEngine;
using System.Collections;

public class ShipScript : MonoBehaviour {

	public LevelManagerScript levelManagerScript;

	public bool isCrashing;
	bool start;
	float maxSpeed;
	float speed;
	float acceleration;
	float jump;
	float zRotate;
	// Use this for initialization
	void Start () {
		levelManagerScript = GameObject.Find("LevelManager").GetComponent<LevelManagerScript>();
		Physics.gravity = new Vector3(0, 0, 0);
		zRotate = 0;
		jump = 11.5f;
		start = levelManagerScript.start;
		speed = 1f;
		maxSpeed = 11.5f;
		acceleration = 43f;
	}

	void CrashFall()
	{
		isCrashing = true;
		rigidbody.isKinematic = true;
	}

	void OnCollisionEnter(Collision collision){
		CrashFall();
		levelManagerScript.EndGame();
	}

	public void Jump()
	{ 
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began)
				speed = -jump;
		}
		//Debug
		if(Input.GetKeyDown("space"))
		{
			speed = -jump;
		}
	}
	// Update is called once per frame
	void Update () {

		start = levelManagerScript.start;

		if(transform.position.x <= -5f)
			transform.position = new Vector3(-5f, transform.position.y, transform.position.z);

		zRotate = 5*speed*(1.51f);
		if(zRotate < -20)
			zRotate = -20;

		if(start || isCrashing)
		{
			transform.rotation = Quaternion.Euler(0, 0, -zRotate);
			transform.Translate(speed * Time.deltaTime,0,0,Space.World);
			if(speed <= maxSpeed)
				speed += Time.deltaTime * acceleration;
			if(transform.position.x >= 3.65f)
			{
				transform.position = new Vector3(3.65f, transform.position.y, transform.position.z);
				isCrashing = false;
			}

		}
	}
}
