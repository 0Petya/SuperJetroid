using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {
	public DoorTrigger[] triggers;
	public bool sticky;
	public AudioClip switchSound;

	private Animator animator;
	private bool down;

	void Start() {
		animator = GetComponent<Animator>();
	}

	void OnTriggerEnter2D(Collider2D target) {
		animator.SetInteger("AnimState", 1);
		if (switchSound)
			AudioSource.PlayClipAtPoint(switchSound, transform.position);
		down = true;

		foreach (DoorTrigger trigger in triggers) {
			if (trigger != null)
				trigger.Toggle(true);
		}
	}

	void OnTriggerExit2D(Collider2D target) {
		if (sticky && down)
			return;
		
		animator.SetInteger("AnimState", 2);
		down = false;

		foreach (DoorTrigger trigger in triggers) {
			if (trigger != null)
				trigger.Toggle(false);
		}
	}

	void OnDrawGizmos() {
		Gizmos.color = sticky ? Color.red : Color.green;
		foreach (DoorTrigger trigger in triggers) {
			if (trigger != null)
				Gizmos.DrawLine(transform.position, trigger.door.transform.position);
		}
	}
}
