using UnityEngine;
using System.Collections;

public class LevelManagerScript : MonoBehaviour {

	public GameObject Player;
	public ShipScript shipScript;
	// Use this for initialization
	void Start () {
		CreatePlayer();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
	}

	public void CreatePlayer(){
		GameObject player = (GameObject)Instantiate(Player);
	}
}
