using UnityEngine;
using System.Collections;

public class ShipScript : MonoBehaviour {

	public LevelManagerScript levelManagerScript;

	bool start;
	float speed;
	float acceleration;
	float jump;
	// Use this for initialization
	void Start () {
		levelManagerScript = GameObject.Find("LevelManager").GetComponent<LevelManagerScript>();
		Physics.gravity = new Vector3(0, 0, 0);
		jump = 7f;
		start = false;
		speed = 1f;
		acceleration = 30f;
	}

	void OnCollisionEnter(Collision collision){
			Destroy (this.gameObject);
			levelManagerScript.CreatePlayer();

	}

	// Update is called once per frame
	void Update () {
		if(transform.position.x <= -5f)
			transform.position = new Vector3(-5f, transform.position.y, transform.position.z);
		if(start == true)
		{
			transform.rotation = Quaternion.Euler(0, 0, -5*speed*(0.80f));
			transform.Translate(speed * Time.deltaTime,0,0,Space.World);
			speed += Time.deltaTime * acceleration;
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
		else
		{
			foreach (Touch touch in Input.touches) {
				if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
					start = true;
					speed = -jump;
			}
			//Debug
			if(Input.GetKeyDown("space"))
			{
				start = true;
				speed = -jump;
			}

		}
	}
}
