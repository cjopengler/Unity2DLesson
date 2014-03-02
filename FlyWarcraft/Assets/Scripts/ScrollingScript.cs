using UnityEngine;
using System.Collections;

/**
 * 视差滚动脚本
 * 
 * */
public class ScrollingScript : MonoBehaviour {

	//滚动的速度
	public Vector2 speed = new Vector2(2, 2);

	//滚动的方向
	public Vector2 direction = new Vector2(0, -1);

	public bool isLinkedToCamera = false;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	protected virtual void Update () {
		Vector3 movement = new Vector3(speed.x * direction.x,
		                               speed.y * direction.y,
		                               0);
		movement *= Time.deltaTime;

		transform.Translate(movement);

		if (isLinkedToCamera) {
			Camera.main.transform.Translate(movement);
		}
	}
}
