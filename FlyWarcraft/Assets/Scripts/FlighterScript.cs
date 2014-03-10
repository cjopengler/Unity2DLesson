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

		WeaponScript weapon = GetComponent<WeaponScript>();

		if (weapon != null) {
			weapon.Fire();
		}



		//  Make sure we are not outside the camera bounds
		var dist = (transform.position - Camera.main.transform.position).z;
		
		var leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).x;
		
		var rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, dist)
			).x;
		
		var topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).y;
		
		var bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, dist)
			).y;
		
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
			transform.position.z
			);
			

	}

	void FixedUpdate() {
		rigidbody2D.velocity = movement;
	}
}
