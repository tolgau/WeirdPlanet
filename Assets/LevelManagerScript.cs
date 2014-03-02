using UnityEngine;
using System.Collections;

public class LevelManagerScript : MonoBehaviour {
	
	public bool start;
	public float objectSpeed;
	public GameObject startText;
	public GameObject Obstacle;
	public GameObject Floor;
	public GameObject Player;
	private Quaternion normalRotation;
	private float initialHeight;
	private float obstacleInterval;
	private GameObject player;
	private GameObject textInstance;
	// Use this for initialization
	void Start () {
		textInstance = (GameObject)Instantiate(startText);
		obstacleInterval = 1.5F;
		initialHeight = 9.5F;
		start = false;
		CreatePlayer();
		InvokeRepeating("InstantiateObstacle", 0.001F, obstacleInterval);
		InstantiateFloor();
		normalRotation = Quaternion.Euler(0,0,0);
		objectSpeed = -3.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began)
			{
				Destroy(textInstance);
				start = true;
			}
		}
		//Debug
		if(Input.GetKeyDown("space"))
		{
			Destroy(textInstance);
			start = true;
		}

	}
	public void EndGame(){
		Destroy(player);
	}

	public void CreatePlayer(){
		player = (GameObject)Instantiate(Player);
	}

	void InstantiateObstacle()
	{
		if(start)
		{
			float x = Random.Range(-2.8F, 2.8F);
			Vector3 obstaclePosition = new Vector3(x,initialHeight,0);
			GameObject obstacle = (GameObject)Instantiate(Obstacle, obstaclePosition, normalRotation);
		}
	}

	void InstantiateFloor()
	{
		GameObject player = (GameObject)Instantiate(Floor);

	}

}
