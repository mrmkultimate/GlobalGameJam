using UnityEngine;
using System.Collections;

public class SoundsL : MonoBehaviour {
	public AudioSource drop;
	public AudioSource Pickup;
	// Use this for initialization
	void OnTriggerStay(Collider other){
		if(other.tag == "Flower"||other.tag == "Salt"||other.tag == "Humous"||other.tag == "Eyeball"){
			if(Input.GetButtonDown ("Fire2")){
				Pickup.Play ();
			}
			if(Input.GetButtonUp ("Fire2")){
				drop.Play();
			}
			
		}
		
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
}
