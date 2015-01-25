using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {
	public GameObject SaltPrefab;
	float timeUntilSpawn = 5.0f;
	float timeSinceMoved = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceMoved += Time.deltaTime;
		if(timeSinceMoved>timeUntilSpawn||StaticVariables.DestroySalt){
			StaticVariables.DestroySalt = true;
			Instantiate(SaltPrefab,transform.position,transform.rotation);
			timeSinceMoved = 0.0f;
		}
		if(StaticVariables.inBurnerSalt||StaticVariables.inMortarSalt||StaticVariables.inPelicanSalt||StaticVariables.pickedUpSaltLeft||StaticVariables.pickedUpSaltRight){
			timeSinceMoved = 0.0f;
		}
	}
}
