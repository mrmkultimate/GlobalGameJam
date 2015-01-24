using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {
	public GameObject SaltPrefab;
	float timeUntilSpawn = 30.0f;
	float timeSinceMoved = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(StaticVariables.pickedUpSaltLeft||StaticVariables.pickedUpSaltRight||timeSinceMoved>0.1f){
			timeSinceMoved += Time.deltaTime;
			if(timeSinceMoved>timeUntilSpawn){
				StaticVariables.DestroySalt = true;
				Instantiate(SaltPrefab);
				timeSinceMoved = 0.0f;
			}
		}
	}
}
