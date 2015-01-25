using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour {
	public AudioSource drop;
	public AudioSource Pickup;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(Input.GetButtonDown ("Fire1")||Input.GetButtonDown ("Fire2")){
			Pickup.Play ();
		}
		if(Input.GetButtonUp ("Fire1")||Input.GetButtonUp ("Fire2")){
			drop.Play();
		}
	}
}
