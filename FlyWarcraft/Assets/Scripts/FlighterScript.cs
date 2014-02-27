using UnityEngine;
using System.Collections;

public class FlighterScript : MonoBehaviour {

	//飞机运行速度
	public Vector2 speed = new Vector2(20, 20);

	//飞机移动
	private Vector2 movement;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//float inputX = Input.GetTouch(0).position.x;
		//float inputY = Input.GetTouch(0).position.y;

		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");


		movement = new Vector2(speed.x * inputX, speed.y * inputY);
	}

	void FixedUpdate() {
		rigidbody2D.velocity = movement;
	}
}
