using UnityEngine;
using System.Collections;

public class ObstacleScript : MonoBehaviour {
	float speed;
	bool start;
	// Use this for initialization
	void Start () {
		start = false;
		speed = -5f;
	}
	
	// Update is called once per frame
	void Update () {
		if(start == true)
		transform.Translate(transform.up*speed*Time.deltaTime);
		else
		{
			foreach (Touch touch in Input.touches) {
				if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
					start = true;
			}
			if(Input.GetKeyDown("space"))
			{
				start = true;
			}

		}
		if(transform.position.y < -9f)
		{
			if(transform.position.x < 0)
				transform.position = new Vector3(1.3f,9f,0f);
			else
				transform.position = new Vector3(-1.3f,9f,0f);

		}
	}
}
