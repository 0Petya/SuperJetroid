using UnityEngine;
using System.Collections;

public class BodyPart : MonoBehaviour {
	private Renderer rend;
	private SpriteRenderer spriteRenderer;
	private Color start;
	private Color end;
	private float t = 0.0f;

	void Start() {
		rend = GetComponent<Renderer>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		start = spriteRenderer.color;
		end = new Color(start.r, start.g, start.b, 0.0f);
	}

	void Update() {
		t += Time.deltaTime;

		rend.material.color = Color.Lerp(start, end, t / 2);

		if (rend.material.color.a <= 0.0)
			Destroy(gameObject);
	}
}
