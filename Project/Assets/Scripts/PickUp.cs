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

	public float burnedAmount = 0.0f;
	bool burnt = false;
	public float crushedAmount = 0.0f;
	bool crushed = false;
	public Rigidbody rigidBody;
	public Material mat;
	public Texture tex1;
	public Texture tex2;
	public Transform pelicanTransform;

	public AudioSource GrindingSound;
	public AudioSource BurningSound;
	public AudioSource BurntSound;
	public AudioSource PickUpSound;
	public AudioSource DropSound;
	public AudioSource DropInMortarSound;
	public AudioSource DropInPelican;
	public AudioSource PelicanSound;


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

				if((tag == "Eyeball")&&(!(StaticVariables.pickedUpPistonRight||StaticVariables.pickedUpSaltRight||StaticVariables.pickedUpHumourRight||StaticVariables.pickedUpFlowerRight))){
					if(!StaticVariables.pickedUpEyeRight){
						PickUpSound.Play ();
					}
					StaticVariables.pickedUpEyeRight = true;
					pickedUpRight = true;
				}
				if((tag == "Salt")&&(!(StaticVariables.pickedUpPistonRight||StaticVariables.pickedUpEyeRight||StaticVariables.pickedUpHumourRight||StaticVariables.pickedUpFlowerRight))){
					if(!StaticVariables.pickedUpSaltRight){
						PickUpSound.Play ();
					}
					StaticVariables.pickedUpSaltRight = true;
					pickedUpRight = true;
				}
				if((tag == "Humour")&&(!(StaticVariables.pickedUpPistonRight||StaticVariables.pickedUpEyeRight||StaticVariables.pickedUpSaltRight||StaticVariables.pickedUpFlowerRight))){
					if(!StaticVariables.pickedUpHumourRight){
						PickUpSound.Play ();
					}
					StaticVariables.pickedUpHumourRight = true;
					pickedUpRight = true;
				}
				if((tag == "Flower")&&(!(StaticVariables.pickedUpPistonRight||StaticVariables.pickedUpEyeRight||StaticVariables.pickedUpSaltRight||StaticVariables.pickedUpHumourRight))){
					if(!StaticVariables.pickedUpFlowerRight){
						PickUpSound.Play ();
					}
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
				if((tag == "Eyeball")&&(!(StaticVariables.pickedUpPistonLeft||StaticVariables.pickedUpSaltLeft||StaticVariables.pickedUpHumourLeft||StaticVariables.pickedUpFlowerLeft))){
					if(!StaticVariables.pickedUpEyeLeft){
						PickUpSound.Play ();
					}
					StaticVariables.pickedUpEyeLeft = true;
					pickedUpLeft = true;
				}
				if((tag == "Salt")&&(!(StaticVariables.pickedUpPistonLeft||StaticVariables.pickedUpEyeLeft||StaticVariables.pickedUpHumourLeft||StaticVariables.pickedUpFlowerLeft))){
					if(!StaticVariables.pickedUpSaltLeft){
						PickUpSound.Play ();
					}
					StaticVariables.pickedUpSaltLeft = true;
					pickedUpLeft = true;
				}
				if((tag == "Humour")&&(!(StaticVariables.pickedUpPistonLeft||StaticVariables.pickedUpEyeLeft||StaticVariables.pickedUpSaltLeft||StaticVariables.pickedUpFlowerLeft))){
					if(!StaticVariables.pickedUpHumourLeft){
						PickUpSound.Play ();
					}
					StaticVariables.pickedUpHumourLeft = true;
					pickedUpLeft = true;
				}
				if((tag == "Flower")&&(!(StaticVariables.pickedUpPistonLeft||StaticVariables.pickedUpEyeLeft||StaticVariables.pickedUpSaltLeft||StaticVariables.pickedUpHumourLeft))){
					if(!StaticVariables.pickedUpFlowerLeft){
						PickUpSound.Play ();
					}
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
					StaticVariables.inPelicanEye = false;
					StaticVariables.inMortarEye = false;
					StaticVariables.inBurnerEye = false;

				}else{
					if(other.tag == "Pelican")
						StaticVariables.inPelicanEye = true;
					else{
						StaticVariables.inPelicanEye = false;
					}
					if(other.tag == "Mortar")
						StaticVariables.inMortarEye = true;
					else{
						StaticVariables.inMortarEye = false;
					}
					if(other.tag == "Burner")
						StaticVariables.inBurnerEye = true;
					else{
						StaticVariables.inBurnerEye = false;
					}
					transform.position = other.transform.position;
					rigidBody.useGravity = false;

				}
			}
			if(tag == "Salt"){
				if(StaticVariables.pickedUpSaltLeft||StaticVariables.pickedUpSaltRight){
					StaticVariables.inPelicanSalt = false;
					StaticVariables.inMortarSalt = false;
					StaticVariables.inBurnerSalt = false;


				}else{
					if(other.tag == "Pelican")
						StaticVariables.inPelicanSalt = true;
					else{
						StaticVariables.inPelicanSalt = false;
					}
					if(other.tag == "Mortar")
						StaticVariables.inMortarSalt = true;
					else{
						StaticVariables.inMortarSalt = false;
					}
					if(other.tag == "Burner")
						StaticVariables.inBurnerSalt = true;
					else{
						StaticVariables.inBurnerSalt = false;
					}
					transform.position = other.transform.position;
					rigidBody.useGravity = false;
				}
			}
			if(tag == "Humour"){
				if(StaticVariables.pickedUpHumourLeft||StaticVariables.pickedUpHumourRight){
					StaticVariables.inPelicanHumour = false;
					StaticVariables.inMortarHumour = false;
					StaticVariables.inBurnerHumour = false;

				}else{
					if(other.tag == "Pelican")
						StaticVariables.inPelicanHumour = true;
					else{
						StaticVariables.inPelicanHumour = false;
					}
					if(other.tag == "Mortar")
						StaticVariables.inMortarHumour = true;
					else{
						StaticVariables.inMortarHumour = false;
					}
					if(other.tag == "Burner")
						StaticVariables.inBurnerHumour = true;
					else{
						StaticVariables.inBurnerHumour = false;
					}
					transform.position = other.transform.position;
					rigidBody.useGravity = false;
				}
			}
			if(tag == "Flower"){
				if(StaticVariables.pickedUpFlowerLeft||StaticVariables.pickedUpFlowerRight){
					StaticVariables.inPelicanFlower = false;
					StaticVariables.inMortarFlower = false;
					StaticVariables.inBurnerFlower = false;

				}else{
					if(other.tag == "Pelican")
						StaticVariables.inPelicanFlower = true;
					else{
						StaticVariables.inPelicanFlower = false;
					}
					if(other.tag == "Mortar")
						StaticVariables.inMortarFlower = true;
					else{
						StaticVariables.inMortarFlower = false;
					}
					if(other.tag == "Burner")
						StaticVariables.inBurnerFlower = true;
					else{
						StaticVariables.inBurnerFlower = false;
					}
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
			rigidbody.velocity = new Vector3(0,0,0);

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
			//	crushedAmount +=Time.deltaTime;
				if(crushedAmount>5.0f){
					StaticVariables.crushedEye = true;
				}
			}
			if(StaticVariables.inBurnerEye){
				burnedAmount+=Time.deltaTime;
				if(burnedAmount>5.0f){
					StaticVariables.heatedEye = true;
						BurningSound.Play();
				}
				if(burnedAmount>15.0f){
					StaticVariables.heatedEye = false;
					StaticVariables.burntEye = true;
					if(!BurntSound.isPlaying)
						BurntSound.Play();
				}
			}
			if(StaticVariables.DestroyEye){
				StaticVariables.burntEye = false;
				StaticVariables.heatedEye = false;
				StaticVariables.crushedEye = false;

				StaticVariables.pickedUpEyeLeft = false;
				StaticVariables.pickedUpEyeRight = false;
				StaticVariables.inBurnerEye = false;
				StaticVariables.inPelicanEye = false;
				StaticVariables.inMortarEye = false;

				StaticVariables.DestroyEye = false;
				Destroy(gameObject);
			}

		}
		if(tag == "Salt"){
			if(StaticVariables.inPelicanSalt){
				
			}
			if(StaticVariables.inMortarSalt){
			//	crushedAmount +=Time.deltaTime;
				if(crushedAmount>5.0f){
					StaticVariables.crushedSalt = true;
				}
			}
			if(StaticVariables.inBurnerSalt){
				burnedAmount+=Time.deltaTime;
				if(burnedAmount>5.0f){
					StaticVariables.heatedSalt = true;
						BurningSound.Play();
					
				}
				if(burnedAmount>15.0f){
					StaticVariables.heatedSalt = false;
					StaticVariables.burntSalt = true;
					if(!BurntSound.isPlaying)
						BurntSound.Play();
				}
			}
			if(StaticVariables.DestroySalt){
				StaticVariables.heatedSalt = false;
				StaticVariables.burntSalt = false;
				StaticVariables.crushedSalt = false;

				StaticVariables.pickedUpSaltLeft = false;
				StaticVariables.pickedUpSaltRight = false;
				StaticVariables.inBurnerSalt = false;
				StaticVariables.inPelicanSalt = false;
				StaticVariables.inMortarSalt = false;

				StaticVariables.DestroySalt = false;
				Destroy(gameObject);
			}
		}
		if(tag == "Humour"){
			if(StaticVariables.inPelicanHumour){
				
			}
			if(StaticVariables.inMortarHumour){
				//crushedAmount +=Time.deltaTime;
				if(crushedAmount>5.0f){
					StaticVariables.crushedHumour = true;
				}
			}
			if(StaticVariables.inBurnerHumour){
				burnedAmount+=Time.deltaTime;
				if(burnedAmount>5.0f){
					StaticVariables.heatedHumour = true;
						BurningSound.Play();
				}
				if(burnedAmount>15.0f){
					StaticVariables.heatedHumour = false;
					StaticVariables.burntHumour = true;
					if(!BurntSound.isPlaying)
						BurntSound.Play();
				}
			}
			if(StaticVariables.DestroyHumour){
				StaticVariables.burntHumour = false;
				StaticVariables.heatedHumour = false;
				StaticVariables.crushedHumour = false;

				StaticVariables.pickedUpHumourLeft = false;
				StaticVariables.pickedUpHumourRight = false;
				StaticVariables.inBurnerHumour = false;
				StaticVariables.inPelicanHumour = false;
				StaticVariables.inMortarHumour = false;

				StaticVariables.DestroyHumour = false;
				Destroy(gameObject);
			}

		}
		if(tag == "Flower"){
			if(StaticVariables.inPelicanFlower){

			}
			if(StaticVariables.inMortarFlower){
				//crushedAmount +=Time.deltaTime;
				if(crushedAmount>5.0f){
					StaticVariables.crushedFlower = true;
				}
			}
			if(StaticVariables.inBurnerFlower){
				burnedAmount+=Time.deltaTime;
				if(burnedAmount>5.0f){
					StaticVariables.heatedFlower = true;
						BurningSound.Play();
				}
				if(burnedAmount>15.0f){
					StaticVariables.heatedFlower = false;
					StaticVariables.burntFlower = true;
					if(!BurntSound.isPlaying)
						BurntSound.Play();
				}
			}
			if(StaticVariables.DestroyFlower){
				StaticVariables.DestroyFlower = false;
				StaticVariables.burntFlower = false;
				StaticVariables.heatedFlower = false;

				StaticVariables.pickedUpFlowerLeft = false;
				StaticVariables.pickedUpFlowerRight = false;
				StaticVariables.inBurnerFlower = false;
				StaticVariables.inPelicanFlower = false;
				StaticVariables.inMortarFlower = false;

				StaticVariables.crushedFlower = false;
				Destroy(gameObject);
			}
		}

		if(StaticVariables.inPelicanHumour&&StaticVariables.heatedHumour&&StaticVariables.inPelicanEye&&StaticVariables.crushedEye&&StaticVariables.inPelicanSalt&&StaticVariables.crushedSalt){

			StaticVariables.inPelicanHumour = false;
			StaticVariables.heatedHumour = false;
			StaticVariables.inPelicanEye = false;
			StaticVariables.crushedEye = false;
			StaticVariables.inPelicanSalt = false;
			StaticVariables.crushedSalt = false;

			StaticVariables.DestroyHumour = true;
			StaticVariables.DestroyEye = true;
			StaticVariables.DestroySalt = true;

			StaticVariables.LaxativePotionCreated = true;
			PelicanSound.Play();
		}
		else if(StaticVariables.inPelicanHumour&&StaticVariables.heatedHumour&&StaticVariables.inPelicanFlower&&StaticVariables.crushedFlower){

			StaticVariables.inPelicanHumour = false;
			StaticVariables.heatedHumour = false;
			StaticVariables.inPelicanFlower = false;
			StaticVariables.crushedFlower = false;

			StaticVariables.DestroyHumour = true;
			StaticVariables.DestroyFlower = true;
			StaticVariables.PomadePotionCreated = true;
			PelicanSound.Play();
		}
		else if(StaticVariables.inPelicanSalt&&StaticVariables.inPelicanFlower&&StaticVariables.heatedFlower&&StaticVariables.crushedSalt){
		
			StaticVariables.inPelicanSalt = false;
			StaticVariables.inPelicanFlower = false;
			StaticVariables.heatedFlower = false;
			StaticVariables.crushedSalt = false;
		
			StaticVariables.DestroySalt = true;
			StaticVariables.DestroyFlower = true;
			StaticVariables.SalvePotionCreated = true;
			PelicanSound.Play();
		}
		else if(StaticVariables.inPelicanEye&&StaticVariables.inPelicanFlower&&StaticVariables.heatedFlower&&StaticVariables.crushedEye){

			StaticVariables.inPelicanEye = false;
			StaticVariables.inPelicanFlower = false;
			StaticVariables.heatedFlower = false;
			StaticVariables.crushedEye = false;

			StaticVariables.DestroyEye = true;
			StaticVariables.DestroyFlower = true;
			StaticVariables.AgilityPotionCreated = true;
			PelicanSound.Play();
		}
		else if(StaticVariables.inPelicanFlower&&StaticVariables.heatedFlower){

			StaticVariables.inPelicanFlower = false;
			StaticVariables.heatedFlower = false;

			StaticVariables.DestroyFlower = true;
			StaticVariables.AntidotePotionCreated = true;
			PelicanSound.Play();
		}
		else if(StaticVariables.inPelicanEye&&StaticVariables.heatedEye){

			StaticVariables.inPelicanEye = false;
			StaticVariables.heatedEye = false;

			StaticVariables.DestroyEye = true;
			StaticVariables.ManaPotionCreated = true;
			PelicanSound.Play();
		}
		else if(StaticVariables.inPelicanFlower&&StaticVariables.crushedFlower){

			StaticVariables.inPelicanFlower = false;
			StaticVariables.crushedFlower = false;
			StaticVariables.DestroyFlower = true;

			StaticVariables.HealthPotionCreated = true;
			PelicanSound.Play();
		}







	}
}
