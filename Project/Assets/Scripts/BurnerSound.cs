using UnityEngine;
using System.Collections;

public class BurnerSound : MonoBehaviour {



	public AudioSource Sizzle;

	void OnTriggerStay(Collider other){
		if(other.tag == "Flower"||other.tag == "Salt"||other.tag == "Humous"||other.tag == "Eyeball"){
			if(!Sizzle.isPlaying){
				Sizzle.Play ();
			}
		}

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
