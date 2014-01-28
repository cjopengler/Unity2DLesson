using UnityEngine;
using System.Collections;


public class PlayerScript : MonoBehaviour {
	
	/// 飞船的速度
	public Vector2 speed = new Vector2(50, 50);

	/// <summary>
	/// 存储飞船的移动
	/// </summary>
	public Vector2 movement;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//获取坐标轴信息
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		//每个方向上移动
		movement = new Vector2(speed.x * inputX,
		                       speed.y * inputY);

		//5 - Shooting
		bool shoot = Input.GetButtonDown("Fire1");
		shoot |= Input.GetButtonDown("Fire2");

		if (shoot) {
			WeaponScript weapon = GetComponent<WeaponScript>();

			weapon.Attack(false);
			SoundEffectsHelper.Instance.MakePlayerShotSound();
		}

		var dist = (transform.position - Camera.main.transform.position).z;

		var leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)).x;

		var rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, dist)).x;

		var topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)).y;

		var bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, dist)).y;

		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
			transform.position.z);

	}

	/// <summary>
	/// Fixeds the update.
	/// </summary>
	void FixedUpdate() {
		//移动游戏物体
		rigidbody2D.velocity = movement;
	}

}
