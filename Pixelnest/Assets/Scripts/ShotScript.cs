using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

	public int damage = 1;

	public bool isEmemyShot = false;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 20);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
