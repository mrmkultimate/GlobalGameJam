using UnityEngine;
using System.Collections;

public class GeneratorFlower : MonoBehaviour {

	public GameObject FlowerPrefab;
	float timeUntilSpawn = 5.0f;
	float timeSinceMoved = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceMoved += Time.deltaTime;
		if(timeSinceMoved>timeUntilSpawn){
			StaticVariables.DestroyFlower = true;
			Instantiate(FlowerPrefab,transform.position,transform.rotation);
			timeSinceMoved = 0.0f;
		}
		if(StaticVariables.inBurnerFlower||StaticVariables.inMortarFlower||StaticVariables.inPelicanFlower||StaticVariables.pickedUpFlowerLeft||StaticVariables.pickedUpFlowerRight){
			timeSinceMoved = 0.0f;
		}
	}
}