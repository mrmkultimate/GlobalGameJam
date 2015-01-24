using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {
	bool selected = false;
	bool pickedUp = false;
	public Rigidbody rigidBody;
	public Material mat;
	public Texture tex1;
	public Texture tex2;

	void OnTriggerEnter(Collider other) {
		Debug.Log("collided");
		if(other.tag == "Player")
			selected = true;
	}
	void OnTriggerStay(Collider other){

		if(other.tag == "Player"){
			if(Input.GetButton ("Fire1")){
				pickedUp = true;
				transform.position = other.transform.position;
			}else{
				pickedUp = false;
			}
		}
	}
	void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			if(Input.GetButton ("Fire1")){
				pickedUp = true;
				transform.position = other.transform.position;
			}else{
			selected = false;
			pickedUp = false;
			}
		}

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(pickedUp){
			rigidBody.useGravity = false;

		}else{
			rigidBody.useGravity = true;
		}

		if(selected){
			mat.color = Color.red;
		}
		else{
			mat.color = Color.white;
		}
	}
}
