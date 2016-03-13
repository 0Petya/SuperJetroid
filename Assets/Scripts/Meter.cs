using UnityEngine;
using System.Collections;

public class Meter : MonoBehaviour {
	public float health = 10;
	public float maxhealth = 10;
	public Texture2D bgTexture;
	public Texture2D healthBarTexture;
	public int iconWidth = 32;
	public Vector2 healthOffset = new Vector2(10, 10);

	private Player player;

	void Start() {
		player = GameObject.FindObjectOfType<Player>();
	}

	void OnGUI() {
		var percent = Mathf.Clamp01(health / maxhealth);

		if (!player)
			percent = 0;

		DrawMeter(healthOffset.x, healthOffset.y, healthBarTexture, bgTexture, percent);
	}

	void DrawMeter(float x, float y, Texture2D texture, Texture2D background, float percent) {
		var bgW = background.width;
		var bgH = background.height;

		GUI.DrawTexture(new Rect(x, y, bgW, bgH), background);

		var nW = ((bgW - iconWidth) * percent) + iconWidth;

		GUI.BeginGroup(new Rect(x, y, nW, bgH));
		GUI.DrawTexture(new Rect(0, 0, bgW, bgH), texture);
		GUI.EndGroup();
	}

	public void Damage(int dmg) {
		health -= dmg;
	}

	void Update() {
		if (!player)
			return;

		if (health <= 0) {
			Explode script = player.GetComponent<Explode>();
			script.OnExplode();
		}
	}
}
