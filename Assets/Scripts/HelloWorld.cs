using UnityEngine;
using System.Collections;

public class HelloWorld : MonoBehaviour {
	public float speed = 2f;

	void Update() {
		transform.Translate(new Vector3(speed, 0, transform.position.z) * Time.deltaTime);
	}
}
