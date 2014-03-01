using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

	//预设好的飞机
	public Transform projectilePrefab;

	public Vector3 positionOffset = new Vector3(0, 10, 0);

	//射击频率 每两个子弹的间隔频率
	public float shootRate = 0.2f;

	private float shootCoolDown;


	// Use this for initialization
	void Start () {
		shootCoolDown = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (shootCoolDown > 0) {
			shootCoolDown -= Time.deltaTime;
		}
	}

	public void Fire() {
		if (CanFire) {
			shootCoolDown = shootRate;

			//创建导弹
			var projectile = Instantiate(projectilePrefab) as Transform;

			//设置的位置是武器的发射位置
			projectile.position = transform.position + positionOffset;

		}
	}

	public bool CanFire {
		get {
			return shootCoolDown <= 0f;
		}

	}
}
