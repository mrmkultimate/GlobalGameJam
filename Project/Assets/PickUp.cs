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
	public Transform pelicanTransform;

	Material newMaterial;

	void OnTriggerEnter(Collider other) {
		Debug.Log("collided");
		if(other.tag == "PlayerLeft")
			selectedLeft = true;
		if(other.tag == "PlayerRight")
			selectedRight = true;
	}
	void OnTriggerStay(Collider other){

		if(other.tag == "PlayerRight"){
			if(Input.GetButton ("Fire1")){

				if((tag == "Eyeball")&&(!(StaticVariables.pickedUpSaltRight||StaticVariables.pickedUpHumourRight||StaticVariables.pickedUpFlowerRight))){
					StaticVariables.pickedUpEyeRight = true;
					pickedUpRight = true;
				}
				if((tag == "Salt")&&(!(StaticVariables.pickedUpEyeRight||StaticVariables.pickedUpHumourRight||StaticVariables.pickedUpFlowerRight))){
					StaticVariables.pickedUpSaltRight = true;
					pickedUpRight = true;
				}
				if((tag == "Humour")&&(!(StaticVariables.pickedUpEyeRight||StaticVariables.pickedUpSaltRight||StaticVariables.pickedUpFlowerRight))){
					StaticVariables.pickedUpHumourRight = true;
					pickedUpRight = true;
				}
				if((tag == "Flower")&&(!(StaticVariables.pickedUpEyeRight||StaticVariables.pickedUpSaltRight||StaticVariables.pickedUpHumourRight))){
					StaticVariables.pickedUpFlowerRight = true;
					pickedUpRight = true;
				}
				if(pickedUpRight)
					transform.position = other.transform.position;
			}else{
				pickedUpRight = false;
				if(tag == "Eyeball"){
					StaticVariables.pickedUpEyeRight = false;
				}
				if(tag == "Salt"){
					StaticVariables.pickedUpSaltRight = false;
				}
				if(tag == "Humour"){
					StaticVariables.pickedUpHumourRight = false;
				}
				if(tag == "Flower"){
					StaticVariables.pickedUpFlowerRight = false;
				}
			}
		}
		if(other.tag == "PlayerLeft"){
			if(Input.GetButton ("Fire2")){
				if((tag == "Eyeball")&&(!(StaticVariables.pickedUpSaltLeft||StaticVariables.pickedUpHumourLeft||StaticVariables.pickedUpFlowerLeft))){
					StaticVariables.pickedUpEyeLeft = true;
					pickedUpLeft = true;
				}
				if((tag == "Salt")&&(!(StaticVariables.pickedUpEyeLeft||StaticVariables.pickedUpHumourLeft||StaticVariables.pickedUpFlowerLeft))){
					StaticVariables.pickedUpSaltLeft = true;
					pickedUpLeft = true;
				}
				if((tag == "Humour")&&(!(StaticVariables.pickedUpEyeLeft||StaticVariables.pickedUpSaltLeft||StaticVariables.pickedUpFlowerLeft))){
					StaticVariables.pickedUpHumourLeft = true;
					pickedUpLeft = true;
				}
				if((tag == "Flower")&&(!(StaticVariables.pickedUpEyeLeft||StaticVariables.pickedUpSaltLeft||StaticVariables.pickedUpHumourLeft))){
					StaticVariables.pickedUpFlowerLeft = true;
					pickedUpLeft = true;
				}
				if(pickedUpLeft)
					transform.position = other.transform.position;
			}else{
				pickedUpLeft = false;
				if(tag == "Eyeball"){
					StaticVariables.pickedUpEyeLeft = false;
				}
				if(tag == "Salt"){
					StaticVariables.pickedUpSaltLeft = false;
				}
				if(tag == "Humour"){
					StaticVariables.pickedUpHumourLeft = false;
				}
				if(tag == "Flower"){
					StaticVariables.pickedUpFlowerLeft = false;
				}
			}
		}
		if((other.tag == "Pelican")||other.tag == "Mortar"||other.tag == "Burner"){
			if(tag == "Eyeball"){
				if(StaticVariables.pickedUpEyeLeft||StaticVariables.pickedUpEyeRight){
				}else{
					if(other.tag == "Pelican")
						StaticVariables.inPelicanEye = true;
					else if(other.tag == "Mortar")
						StaticVariables.inMortarEye = true;
					else if(other.tag == "Burner")
						StaticVariables.inBurnerEye = true;
					transform.position = other.transform.position;
					rigidBody.useGravity = false;

				}
			}
			if(tag == "Salt"){
				if(StaticVariables.pickedUpSaltLeft||StaticVariables.pickedUpSaltRight){
				}else{
					if(other.tag == "Pelican")
						StaticVariables.inPelicanSalt = true;
					else if(other.tag == "Mortar")
						StaticVariables.inMortarSalt = true;
					else if(other.tag == "Burner")
						StaticVariables.inBurnerSalt = true;
					transform.position = other.transform.position;
					rigidBody.useGravity = false;
				}
			}
			if(tag == "Humour"){
				if(StaticVariables.pickedUpHumourLeft||StaticVariables.pickedUpHumourRight){
				}else{
					if(other.tag == "Pelican")
						StaticVariables.inPelicanHumour = true;
					else if(other.tag == "Mortar")
						StaticVariables.inMortarHumour = true;
					else if(other.tag == "Burner")
						StaticVariables.inBurnerHumour = true;
					transform.position = other.transform.position;
					rigidBody.useGravity = false;
				}
			}
			if(tag == "Flower"){
				if(StaticVariables.pickedUpFlowerLeft||StaticVariables.pickedUpFlowerRight){
				}else{
					if(other.tag == "Pelican")
						StaticVariables.inPelicanFlower = true;
					else if(other.tag == "Mortar")
						StaticVariables.inMortarFlower = true;
					else if(other.tag == "Burner")
						StaticVariables.inBurnerFlower = true;
					transform.position = other.transform.position;
					rigidBody.useGravity = false;
				}
			}

		}if(other.tag == "Piston"){
			if(StaticVariables.inMortarEye&&tag == "Eyeball"){
				crushedAmount+=Time.deltaTime;
			}
			if(StaticVariables.inMortarSalt&&tag == "Salt"){
				crushedAmount+=Time.deltaTime;
			}
			if(StaticVariables.inMortarHumour&&tag == "Humour"){
				crushedAmount+=Time.deltaTime;
			}
			if(StaticVariables.inMortarFlower&&tag == "Flower"){
				crushedAmount+=Time.deltaTime;
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
				if(tag == "Eyeball"){
					StaticVariables.pickedUpEyeRight = false;
				}
				if(tag == "Salt"){
					StaticVariables.pickedUpSaltRight = false;
				}
				if(tag == "Humour"){
					StaticVariables.pickedUpHumourRight = false;
				}
				if(tag == "Flower"){
					StaticVariables.pickedUpFlowerRight = false;
				}
			}
		}
		if(other.tag == "PlayerLeft"){

			if(Input.GetButton ("Fire2")&&(!pickedUpRight)){
				if(pickedUpLeft){
					transform.position = other.transform.position;
				}else{
					selectedLeft = false;
				}
			}else{
				selectedLeft = false;
				pickedUpLeft = false;
				if(tag == "Eyeball"){
					StaticVariables.pickedUpEyeLeft = false;
				}
				if(tag == "Salt"){
					StaticVariables.pickedUpSaltLeft = false;
				}
				if(tag == "Humour"){
					StaticVariables.pickedUpHumourLeft = false;
				}
				if(tag == "Flower"){
					StaticVariables.pickedUpFlowerLeft = false;
				}
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

		if(tag == "Eyeball"){
			if(StaticVariables.inPelicanEye){

			}
			if(StaticVariables.inMortarEye){

			}
			if(StaticVariables.inBurnerEye){
				burnedAmount+=Time.deltaTime;
			}

		}
		if(tag == "Salt"){
			if(StaticVariables.inPelicanSalt){
				
			}
			if(StaticVariables.inMortarSalt){
				
			}
			if(StaticVariables.inBurnerSalt){
				burnedAmount+=Time.deltaTime;
			}

		}
		if(tag == "Humour"){
			if(StaticVariables.inPelicanHumour){
				
			}
			if(StaticVariables.inMortarHumour){
				
			}
			if(StaticVariables.inBurnerHumour){
				burnedAmount+=Time.deltaTime;
			}

		}
		if(tag == "Flower"){
			if(StaticVariables.inPelicanFlower){
				
			}
			if(StaticVariables.inMortarFlower){
				
			}
			if(StaticVariables.inBurnerFlower){
				burnedAmount+=Time.deltaTime;
			}

		}



	}
}
