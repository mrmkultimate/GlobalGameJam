using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {
	bool selectedRight = false;
	bool pickedUpRight = false;
	bool selectedLeft = false;
	bool pickedUpLeft = false;
	bool inJar = true;
	bool inMortar = false;
	bool inBurner = false;
	bool inDropBox = false;
	bool inPelican = false;

	float burnedAmount = 0.0f;
	bool burnt = false;
	float crushedAmount = 0.0f;
	bool crushed = false;
	public Rigidbody rigidBody;
	public Material mat;
	public Texture tex1;
	public Texture tex2;

	void OnTriggerEnter(Collider other) {
		Debug.Log("collided");
		if(other.tag == "PlayerLeft")
			selectedLeft = true;
		if(other.tag == "PlayerRight")
			selectedRight = true;
	}
	void OnTriggerStay(Collider other){

		if(other.tag == "PlayerRight"){
			if(Input.GetButton ("Fire1")&&(!pickedUpLeft)){
				pickedUpRight = true;
				transform.position = other.transform.position;
			}else{
				pickedUpRight = false;
			}
		}
		if(other.tag == "PlayerLeft"){
			if(Input.GetButton ("Fire2")&&(!pickedUpRight)){
				pickedUpLeft = true;
				transform.position = other.transform.position;
			}else{
				pickedUpLeft = false;
			}
		}
	}
	void OnTriggerExit(Collider other){
		if(other.tag == "PlayerRight"){
			if(Input.GetButton ("Fire1")&&(!pickedUpLeft)){
				pickedUpRight = true;
				transform.position = other.transform.position;
			}else{
			selectedRight = false;
			pickedUpRight = false;
			}
		}
		if(other.tag == "PlayerLeft"){
			if(Input.GetButton ("Fire2")&&(!pickedUpRight)){
				pickedUpLeft = true;
				transform.position = other.transform.position;
			}else{
				selectedLeft = false;
				pickedUpLeft = false;
			}
		}
	}

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
		if(pickedUpLeft||pickedUpRight){
			rigidBody.useGravity = false;
			transform.rotation.eulerAngles.Set (0.0f,0.0f,0.0f);
			rigidBody.freezeRotation = true;

		}else{
			rigidBody.useGravity = true;
			rigidBody.freezeRotation = false;

		}

		if(selectedRight||selectedLeft){
			mat.color = Color.red;
		}
		else{
			mat.color = Color.white;
		}
	}
}
