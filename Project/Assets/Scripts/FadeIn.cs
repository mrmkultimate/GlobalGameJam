using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {

	public GameObject splash1;
	public GameObject splash2;
	public Camera leftEye;
	public Camera rightEye;
	float elapsedTime = 0;

	bool keypress = false;

	void Awake() {

		splash1.SetActive(false);
		splash2.SetActive(false);

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.anyKeyDown) {
			keypress = true;
			splash1.SetActive (true);

		}

		if (keypress) {
			elapsedTime += Time.deltaTime;
				
			if (elapsedTime > 10.0f) {
				Application.LoadLevel("Apothequery");

			} else if (elapsedTime > 6.0f) {
				splash1.SetActive (false);
				splash2.SetActive (true);
				leftEye.backgroundColor = new Color32(193, 193, 193, 255);
				rightEye.backgroundColor = new Color32(193, 193, 193, 255);
			}
			
		}

	}
}
