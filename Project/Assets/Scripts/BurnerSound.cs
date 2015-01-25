using UnityEngine;
using System.Collections;

public class BurnerSound : MonoBehaviour {



	public AudioSource Sizzle;
	public GameObject particle;
	Object temp;

	void OnTriggerStay(Collider other){
		if(other.tag == "Flower"||other.tag == "Salt"||other.tag == "Humous"||other.tag == "Eyeball"){
			if(!Sizzle.isPlaying){
				temp = Instantiate(particle);
				Destroy(temp, 5.0f);
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
