using UnityEngine;
using System.Collections;

public class PelicanSounds : MonoBehaviour {
	public AudioSource pelicanSound;
	public GameObject Flower;
	public GameObject Salt;
	public GameObject Eyeball;
	public GameObject Humour;
	public GameObject GeneratorFlower;
	public GameObject GeneratorSalt;
	public GameObject GeneratorEyeball;
	public GameObject GeneratorHumour;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		if(StaticVariables.HealthPotionCreated){


			pelicanSound.Play ();

		}
		if(StaticVariables.ManaPotionCreated){

			pelicanSound.Play ();
		}
		if(StaticVariables.AntidotePotionCreated){
			pelicanSound.Play ();
			
		}
		if(StaticVariables.AgilityPotionCreated){
			pelicanSound.Play ();
			
		}
		   if(StaticVariables.SalvePotionCreated){
			
			pelicanSound.Play ();
		}
		   if(StaticVariables.PomadePotionCreated){
			pelicanSound.Play ();
			
		}
		   if(StaticVariables.LaxativePotionCreated){
			
			pelicanSound.Play ();
		}
	
	}
}
