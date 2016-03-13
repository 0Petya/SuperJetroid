using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {
	public int damage = 1;
	public int strength = 1;

	private Player player;
	private Meter meter;

	void Start() {
		player = GameObject.FindObjectOfType<Player>();
		meter = GameObject.FindObjectOfType<Meter>();
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.gameObject.tag == "Player")
			DamagePlayer();
	}

	void OnCollisionEnter2D(Collision2D target) {
		if (target.gameObject.tag == "Player")
			DamagePlayer();
	}

	void DamagePlayer() {
		Meter meterScript = meter.GetComponent<Meter>();
		meterScript.Damage(damage);
		Player playerScript = player.GetComponent<Player>();
		playerScript.Knockback(strength);
	}
}
