using UnityEngine;
using System.Collections;

public class ShipScript : MonoBehaviour {

	public LevelManagerScript levelManagerScript;

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

	void OnCollisionEnter(Collision collision){
			levelManagerScript.EndGame();

	}

	// Update is called once per frame
	void Update () {
		if(!start)
			start = levelManagerScript.start;

		if(transform.position.x <= -5f)
			transform.position = new Vector3(-5f, transform.position.y, transform.position.z);
		if(start)
		{
			zRotate = 3*speed*(1.2f);
			transform.rotation = Quaternion.Euler(0, 0, -zRotate);
			transform.Translate(speed * Time.deltaTime,0,0,Space.World);
			if(speed <= maxSpeed)
				speed += Time.deltaTime * acceleration;
		}

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
}
