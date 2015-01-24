using UnityEngine;
using System.Collections;

public class SoundsL : MonoBehaviour {
	public AudioSource drop;
	public AudioSource Pickup;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown ("Fire2")){
			Pickup.Play ();
		}
		if(Input.GetButtonUp ("Fire2")){
			drop.Play();
		}
	}
}
