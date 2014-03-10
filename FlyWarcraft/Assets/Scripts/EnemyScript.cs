using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	//是否产生
	private bool hasSpawn;


	private MoveScript moveScript;

	void Awake() {
		hasSpawn = false;
		moveScript = GetComponent<MoveScript>();
	}

	// Use this for initialization
	void Start () {
		//Disable所有的东西

		hasSpawn = false;

		//Disable colider2D
		collider2D.enabled = false;

		//Disable 移动脚本
		moveScript.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (!hasSpawn) {
			if (renderer.isVisibleFrom(Camera.main)) {
				//产生
				Spawn();
			}
		} else {
			//Fire AI

			if (!renderer.isVisibleFrom(Camera.main)) {
				//看不到了 那就destroy
				Destroy(gameObject);
			}
		}
	}

	private void Spawn() {
		hasSpawn = true;
		collider2D.enabled = true;
		moveScript.enabled = true;
	}
}
