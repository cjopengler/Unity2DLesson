using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour {

	private bool hasSpawn;

	private MoveScript moveScript;
	private WeaponScript[] weapons;
	private Animator animator;
	private SpriteRenderer[] renderers;

	public float minAttackCooldown = 0.5f;
	public float maxAttackCooldown = 2f;

	private float aiCooldown;
	private bool isAttacking;
	private Vector2 positionTarget;

	void Awake() {
		weapons = GetComponentsInChildren<WeaponScript>();

		moveScript = GetComponent<MoveScript>();

		animator = GetComponent<Animator>();

		renderers = GetComponentsInChildren<SpriteRenderer>();

	}


	// Use this for initialization
	void Start () {
		hasSpawn = false;

		collider2D.enabled = false;
		moveScript.enabled = false;

		foreach (WeaponScript weapon in weapons) {
			weapon.enabled = false;
		}

		isAttacking = false;
		aiCooldown = maxAttackCooldown;
	}

	void Update() {
		if (hasSpawn == false) {
			if (renderers[0].IsVisibleFrom(Camera.main)) {
				Spawn();
			}
		} else {
			aiCooldown -= Time.deltaTime;

			if (aiCooldown <= 0f) {
				isAttacking = !isAttacking;

				aiCooldown = Random.Range(minAttackCooldown, maxAttackCooldown);

				positionTarget = Vector2.zero;

				animator.SetBool("Attack", isAttacking);
			}

			if (isAttacking) {
				moveScript.direction = Vector2.zero;

				foreach (WeaponScript weapon in weapons) {
					if (weapon != null &&
					    weapon.enabled &&
					    weapon.CanAttack) {

						weapon.Attack(true);
						SoundEffectsHelper.Instance.MakeEnemyShotSound();
					}
				}
			} else {

				if (positionTarget == Vector2.zero) {
					Vector2 randPoint = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f));

					positionTarget = Camera.main.ViewportToWorldPoint(randPoint);
				}

				if (collider2D.OverlapPoint(positionTarget)) {
					positionTarget = Vector2.zero;
				}

				Vector3 direction = ((Vector3)positionTarget - this.transform.position);
				moveScript.direction = Vector3.Normalize(direction);

			}
		}
	}

		private void Spawn() {
			hasSpawn = true;
			
			// Enable everything
			// -- Collider
			collider2D.enabled = true;
			// -- Moving
			moveScript.enabled = true;
			// -- Shooting
			foreach (WeaponScript weapon in weapons)
			{
				weapon.enabled = true;
			}
			
			// Stop the main scrolling
			foreach (ScrollingScript scrolling in FindObjectsOfType<ScrollingScript>())
			{
				if (scrolling.isLinkedToCamera)
				{
					scrolling.speed = Vector2.zero;
				}
			}

		}

		void OnTriggerEnter2D(Collider2D otherCollider2D) {
			// Taking damage? Change animation
			ShotScript shot = otherCollider2D.gameObject.GetComponent<ShotScript>();
			if (shot != null)
			{
				if (shot.isEmemyShot == false)
				{
					// Stop attacks and start moving awya
					aiCooldown = Random.Range(minAttackCooldown, maxAttackCooldown);
					isAttacking = false;
					
					// Change animation
					animator.SetTrigger("Hit");
				}
			}
		}

		void OnDrawGizmos()
		{
			// A little tip: you can display debug information in your scene with Gizmos
			if (hasSpawn && isAttacking == false)
			{
				Gizmos.DrawSphere(positionTarget, 0.25f);
			}
		}


}
