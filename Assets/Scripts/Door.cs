using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public float closeDelay = 0.5f;
	public AudioClip doorSound;

	private Animator animator;

	void Start() {
		animator = GetComponent<Animator>();
	}

	void DisableCollider2D() {
		GetComponent<Collider2D>().enabled = false;
	}

	void EnableCollider2D() {
		GetComponent<Collider2D>().enabled = true;
	}

	public void Open() {
		animator.SetInteger("AnimState", 1);
		if (doorSound)
			AudioSource.PlayClipAtPoint(doorSound, transform.position);
	}

	public void Close() {
		StartCoroutine(CloseNow());
	}

	private IEnumerator CloseNow() {
		yield return new WaitForSeconds(closeDelay);
		animator.SetInteger("AnimState", 2);
		if (doorSound)
			AudioSource.PlayClipAtPoint(doorSound, transform.position);
	}
}
