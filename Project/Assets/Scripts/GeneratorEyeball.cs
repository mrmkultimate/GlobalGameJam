using UnityEngine;
using System.Collections;

public class GeneratorEyeball : MonoBehaviour {

	
	public GameObject EyeballPrefab;
	float timeUntilSpawn = 5.0f;
	float timeSinceMoved = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

			timeSinceMoved += Time.deltaTime;
		if(timeSinceMoved>timeUntilSpawn||StaticVariables.DestroyEye){
				StaticVariables.DestroyEye = true;
				Instantiate(EyeballPrefab,transform.position,transform.rotation);
				timeSinceMoved = 0.0f;
			}
		if(StaticVariables.inBurnerEye||StaticVariables.inMortarEye||StaticVariables.inPelicanEye||StaticVariables.pickedUpEyeLeft||StaticVariables.pickedUpEyeRight){
			timeSinceMoved = 0.0f;
		}

	}
}