using UnityEngine;
using System.Collections;

public class GeneratorEyeball : MonoBehaviour {

	
	public GameObject EyeballPrefab;
	float timeUntilSpawn = 30.0f;
	float timeSinceMoved = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(StaticVariables.pickedUpEyeLeft||StaticVariables.pickedUpEyeRight||timeSinceMoved>0.1f){
			timeSinceMoved += Time.deltaTime;
			if(timeSinceMoved>timeUntilSpawn){
				StaticVariables.DestroyEye = true;
				Instantiate(EyeballPrefab);
				timeSinceMoved = 0.0f;
			}
		}
	}
}