using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ClickToContinue : MonoBehaviour {
	public string scene;

	private bool loadLock;

	void Update() {
		if (Input.GetMouseButton(0) && !loadLock)
			LoadScene();
	}

	void LoadScene() {
		loadLock = true;
		SceneManager.LoadScene(scene);
	}
}
