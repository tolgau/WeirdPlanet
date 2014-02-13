using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
	bool start;
	float speed;
	float acceleration;
	float jump;
	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3(0, 0, 0);
		jump = 6f;
		start = false;
		speed = 1f;
		acceleration = 15f;
	}

	void OnCollisionEnter( Collision collision){
			Destroy (this.gameObject);
	}

	// Update is called once per frame
	void Update () {
		if(start == true)
		{
			transform.rotation = Quaternion.Euler(0, 0, -5*speed);
			transform.Translate(speed * Time.deltaTime,0,0,Space.World);
			speed += Time.deltaTime * acceleration;
			if (Input.GetKeyDown("space"))
				speed = -jump;
		}
		else
		{
			if (Input.GetKeyDown("space"))
				start = true;
				speed = -jump;
		}

	}
}
