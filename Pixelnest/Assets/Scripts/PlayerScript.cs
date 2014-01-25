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
	}

	/// <summary>
	/// Fixeds the update.
	/// </summary>
	void FixedUpdate() {
		//移动游戏物体
		rigidbody2D.velocity = movement;
	}

}
