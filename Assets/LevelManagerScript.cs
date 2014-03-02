using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManagerScript : MonoBehaviour {
	
	public bool start;
	public float objectSpeed;
	public GameObject startText;
	public GameObject Obstacle;
	public GameObject Floor;
	public GameObject Player;
	private int score;
	private bool gameEnded;
	private Quaternion normalRotation;
	private float initialHeight;
	private float obstacleInterval;
	private GameObject player;
	private GameObject textInstance;
	private List<GameObject> floorList = new List<GameObject>();
	private List<GameObject> obstacleList = new List<GameObject>();
	// Use this for initialization
	void Start () {
		obstacleInterval = 1.5F;
		initialHeight = 9.5F;
		normalRotation = Quaternion.Euler(0,0,0);
		objectSpeed = -3.5f;
		InitiateGame();
	}

	public void RegisterObstacle(GameObject obstacle){
		//Add tile to the list
		obstacleList.Add(obstacle);
	}

	public void RegisterFloor(GameObject floor){
		//Add tile to the list
		floorList.Add(floor);
	}

	private void InitiateGame()
	{
		gameEnded = false;
		textInstance = (GameObject)Instantiate(startText);
		start = false;
		CreatePlayer();
		InvokeRepeating("InstantiateObstacle", 0.001F, obstacleInterval);
		InstantiateFloor();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began)
			{
				if(gameEnded)
				{
					if(!player.GetComponent<ShipScript>().isCrashing)
					{
						DestroyEverything();
						InitiateGame();
					}
				}
				else
				{
					Destroy(textInstance);
					start = true;
					player.GetComponent<ShipScript>().Jump();
				}
			}
		}
		//Debug
		if(Input.GetKeyDown("space"))
		{
			if(gameEnded)
			{
				if(!player.GetComponent<ShipScript>().isCrashing)
				{
					DestroyEverything();
					InitiateGame();
				}
			}
			else
			{
				Destroy(textInstance);
				start = true;
				player.GetComponent<ShipScript>().Jump();
			}
		}
	}

	public void DestroyEverything()
	{
		foreach(GameObject obstacle in obstacleList)
		{
			Destroy(obstacle);
			CancelInvoke("InstantiateObstacle");
		}
		foreach(GameObject floor in floorList)
		{
			Destroy(floor);
			//CancelInvoke("InstantiateObstacle");
		}
		Destroy(player);
	}

	public void EndGame(){
		gameEnded = true;
		start = false;
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
			RegisterObstacle(obstacle);
		}
	}

	void InstantiateFloor()
	{
		GameObject floor = (GameObject)Instantiate(Floor);
		RegisterFloor(floor);

	}

}
