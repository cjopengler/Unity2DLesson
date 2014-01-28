using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public int hp = 2;

	public bool isEnemy = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		ShotScript shot = collider.gameObject.GetComponent<ShotScript>();

		if (shot != null) {
			if (shot.isEmemyShot != isEnemy) {
				hp -= shot.damage;

				Destroy(shot.gameObject);

				if (hp <= 0) {
					SpecialEffectsHelper.Instance.Explosion(transform.position);
					SoundEffectsHelper.Instance.MakeExplosionSound();
					Destroy(gameObject);
				}
			}
		}
	}
}
