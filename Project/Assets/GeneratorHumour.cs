using UnityEngine;
using System.Collections;

public class GeneratorHumour : MonoBehaviour {
	public GameObject HumourPrefab;
	float timeUntilSpawn = 5.0f;
	float timeSinceMoved = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceMoved += Time.deltaTime;
		if(timeSinceMoved>timeUntilSpawn){
			StaticVariables.DestroyHumour = true;
			Instantiate(HumourPrefab,transform.position,transform.rotation);
			timeSinceMoved = 0.0f;
		}
		if(StaticVariables.inBurnerHumour||StaticVariables.inMortarHumour||StaticVariables.inPelicanHumour||StaticVariables.pickedUpHumourLeft||StaticVariables.pickedUpHumourRight){
			timeSinceMoved = 0.0f;
		}
	}
}
