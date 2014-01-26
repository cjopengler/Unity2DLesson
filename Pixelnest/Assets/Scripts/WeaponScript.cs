using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

	public Transform shotPrefab;

	public float shootingRate = 0.25f;

	public float shootColdown;

	// Use this for initialization
	void Start () {
		shootColdown = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (shootColdown > 0) {
			shootColdown -= Time.deltaTime;
		}
	}

	public bool CanAttack {
		get {
			return shootColdown <= 0f;
		}
	}

	public void Attack(bool isEnemy) {
		if (CanAttack) {
			shootColdown = shootingRate;

			var shotTransofrm = Instantiate(shotPrefab) as Transform;

			shotTransofrm.position = transform.position;

			ShotScript shot = shotTransofrm.gameObject.GetComponent<ShotScript>();

			if (shot != null) {
				shot.isEmemyShot = isEnemy;
			}

			MoveScript move = shotTransofrm.gameObject.GetComponent<MoveScript>();

			if (move != null) {
				move.direction = this.transform.right;
			}
		}
	}
}
