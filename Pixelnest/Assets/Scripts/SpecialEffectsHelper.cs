using UnityEngine;
using System.Collections;

public class SpecialEffectsHelper : MonoBehaviour {

	public static SpecialEffectsHelper Instance;

	public ParticleSystem smokeEffect;
	public ParticleSystem fireEffect;

	void Awake() {
		if (Instance != null) {
			Debug.LogError("Multiple instance of Special Effects Heloper is created");
		}

		Instance = this;
	}

	public void Explosion(Vector3 position) {
		instantiate(smokeEffect, position);
		instantiate(fireEffect, position);
	}

	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position) {
		ParticleSystem newParticleSystem = Instantiate(
			prefab,
			position,
			Quaternion.identity
			) as ParticleSystem;

		Destroy(newParticleSystem.gameObject, newParticleSystem.startLifetime);

		return newParticleSystem;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
