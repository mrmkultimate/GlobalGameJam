using UnityEngine;
using System.Collections;

public class PickUpPiston : MonoBehaviour {

	bool pickedUpRight = false;
	bool pickedUpLeft = false;
	bool selectedRight = false;
	bool selectedLeft = false;

	public Rigidbody rigidBody;
	public Material mat;
	public Texture tex1;
	public Texture tex2;
	public Transform pelicanTransform;
	public CapsuleCollider capsCollider;

	void OnTriggerEnter(Collider other){
		if(other.tag == "PlayerLeft")
			selectedLeft = true;
		if(other.tag == "PlayerRight")
			selectedRight = true;
	}
	void OnTriggerStay(Collider other){
		if(other.tag == "PlayerRight"){
			if(Input.GetButton ("Fire1")){
				if(!(StaticVariables.pickedUpPistonLeft)){//||StaticVariables.pickedUpEyeRight||StaticVariables.pickedUpSaltRight||StaticVariables.pickedUpHumourRight||StaticVariables.pickedUpFlowerRight)){

					StaticVariables.pickedUpPistonRight = true;
					pickedUpRight = true;
					transform.position = other.transform.position;
				}else{
					StaticVariables.pickedUpPistonRight = false;
					pickedUpRight = false;
				}
			}else{
				pickedUpRight = false;
			}
		}else if(other.tag == "PlayerLeft"){
			if(Input.GetButton ("Fire2")){
				if(!(StaticVariables.pickedUpPistonRight)){//||StaticVariables.pickedUpEyeLeft||StaticVariables.pickedUpSaltLeft||StaticVariables.pickedUpHumourLeft||StaticVariables.pickedUpFlowerLeft)){
					StaticVariables.pickedUpPistonLeft = true;
					pickedUpLeft = true;
					transform.position = other.transform.position;
				}else{
					StaticVariables.pickedUpPistonLeft = false;
					pickedUpLeft = false;
				}
			}else{
				pickedUpLeft = false;
			}
		}
	}

		void OnTriggerExit(Collider other){
			if(other.tag == "PlayerRight"){
				if(Input.GetButton ("Fire1")&&(!pickedUpLeft)){
					if(pickedUpRight){
						transform.position = other.transform.position;
					}else{
						selectedRight = false;
					}
			}else{
				selectedRight = false;
				pickedUpRight = false;
				StaticVariables.pickedUpPistonRight = false;
			}
		}
		if(other.tag == "PlayerLeft"){
				if(Input.GetButton("Fire2")&&(!pickedUpRight)){
					if(pickedUpLeft){
						transform.position = other.transform.position;
					}else{
						selectedLeft = false;
					}

				}else{
				selectedLeft = false;
				pickedUpLeft = false;
				StaticVariables.pickedUpPistonLeft = false;
				}
			}
		}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(StaticVariables.DestroyPiston){
			StaticVariables.DestroyPiston = false;
			Destroy(gameObject);
		}

		if(pickedUpLeft||pickedUpRight){
			rigidBody.useGravity = false;
			transform.rotation.eulerAngles.Set (0.0f,0.0f,0.0f);
			rigidBody.freezeRotation = true;
			rigidBody.velocity = new Vector3(0,0,0);
			capsCollider.isTrigger = true;
			
		}else{
			rigidBody.useGravity = true;
			rigidBody.freezeRotation = false;
			capsCollider.isTrigger = false;
		}
		
		if(selectedRight||selectedLeft){
			mat.color = Color.red;
		}
		else{
			mat.color = Color.white;
		}
	}
}
