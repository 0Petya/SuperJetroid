using UnityEngine;
using System.Collections;

public class RandomSprite : MonoBehaviour {
	public Sprite[] sprites;
	public string resourceName;
	public int currentSprite = -1;

	void Start() {
		if (resourceName != "") {
			sprites = Resources.LoadAll<Sprite>(resourceName);

			if (currentSprite == -1 || currentSprite > sprites.Length)
				currentSprite = Random.Range(0, sprites.Length);

			GetComponent<SpriteRenderer>().sprite = sprites[currentSprite];
		}
	}
}
