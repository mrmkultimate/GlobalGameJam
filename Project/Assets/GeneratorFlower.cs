using UnityEngine;
using System.Collections;

public class GeneratorFlower : MonoBehaviour {

	public GameObject FlowerPrefab;
	float timeUntilSpawn = 30.0f;
	float timeSinceMoved = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(StaticVariables.pickedUpFlowerLeft||StaticVariables.pickedUpFlowerRight||timeSinceMoved>0.1f){
			timeSinceMoved += Time.deltaTime;
			if(timeSinceMoved>timeUntilSpawn){
				StaticVariables.DestroyFlower = true;
				Instantiate(FlowerPrefab);
				timeSinceMoved = 0.0f;
			}
		}
}
}