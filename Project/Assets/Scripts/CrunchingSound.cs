using UnityEngine;
using System.Collections;

public class CrunchingSound : MonoBehaviour {

	public AudioSource Crunch;
	
	void OnTriggerStay(Collider other){
		if(other.tag == "Flower"||other.tag == "Salt"||other.tag == "Humous"||other.tag == "Eyeball"){
			if(!Crunch.isPlaying){
				Crunch.Play ();
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
