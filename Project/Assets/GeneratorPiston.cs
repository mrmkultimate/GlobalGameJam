using UnityEngine;
using System.Collections;

public class GeneratorPiston : MonoBehaviour {
	public GameObject PistonPrefab;
	float timeUntilSpawn = 3.0f;
	float timeSinceMoved = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceMoved += Time.deltaTime;
		if(timeSinceMoved>timeUntilSpawn){
			StaticVariables.DestroyPiston = true;
			Instantiate(PistonPrefab,transform.position,transform.rotation);
			timeSinceMoved = 0.0f;
		}
		if(StaticVariables.pickedUpPistonLeft||StaticVariables.pickedUpPistonRight){
			timeSinceMoved = 0.0f;
		}
	}
}