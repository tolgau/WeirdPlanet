using UnityEngine;
using System.Collections;

public class ObstacleScript : MonoBehaviour {
	public LevelManagerScript levelManagerScript;
	float speed;
	bool start;
	// Use this for initialization
	void Start () {
		levelManagerScript = GameObject.Find("LevelManager").GetComponent<LevelManagerScript>();
		start = levelManagerScript.start;
		speed = levelManagerScript.objectSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if(!start)
			start = levelManagerScript.start;

		if(start)
			transform.Translate(transform.up*speed*Time.deltaTime);

		if(transform.position.y <= -9.5)
			Destroy(this.gameObject);
	}
}
