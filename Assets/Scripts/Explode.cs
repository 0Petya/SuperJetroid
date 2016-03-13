using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Explode : MonoBehaviour {
	public BodyPart bodyPart;
	public int totalParts = 5;

	void OnTriggerEnter2D(Collider2D target) {
		if (target.gameObject.tag == "Deadly")
			OnExplode();
	}

	void OnCollisionEnter2D(Collision2D target) {
		if (target.gameObject.tag == "Deadly")
			OnExplode();
	}

	public void OnExplode() {
		Destroy(gameObject);

		var t = transform;

		for (int i = 0; i < totalParts; i++) {
			t.TransformPoint(0, -100, 0);
			BodyPart clone = Instantiate(bodyPart, t.position, Quaternion.identity) as BodyPart;
			clone.GetComponent<Rigidbody2D>().AddForce(Vector3.right * Random.Range(-50, 50));
			clone.GetComponent<Rigidbody2D>().AddForce(Vector3.up * Random.Range(100, 400));
		}

		GameObject go = new GameObject("ClickToContinue");
		ClickToContinue script = go.AddComponent<ClickToContinue>();
		script.scene = SceneManager.GetActiveScene().name;
		go.AddComponent<DisplayRestartText>();
	}
}
