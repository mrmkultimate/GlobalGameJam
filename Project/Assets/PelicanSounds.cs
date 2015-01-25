using UnityEngine;
using System.Collections;

public class PelicanSounds : MonoBehaviour {
	public AudioSource pelicanSound;
	public GameObject HealthPotion;
	public GameObject ManaPotion;
	public GameObject AntidotePotion;
	public GameObject AgilityPotion;
	public GameObject SalvePotion;
	public GameObject PomadePotion;
	public GameObject LaxativePotion;
	public Material bottle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
		if(StaticVariables.HealthPotionCreatedSound){

			pelicanSound.Play ();
			StaticVariables.HealthPotionCreatedSound = false;
			Object temp = Instantiate(HealthPotion,transform.position,transform.rotation);
			Destroy(temp,3.0f);
			bottle.color = Color.red;
		}
		if(StaticVariables.ManaPotionCreatedSound){

			pelicanSound.Play ();
			StaticVariables.ManaPotionCreatedSound = false;
			Object temp = Instantiate(ManaPotion,transform.position,transform.rotation);
			Destroy(temp,3.0f);
			bottle.color = Color.blue;
		}
		if(StaticVariables.AntidotePotionCreatedSound){
			pelicanSound.Play ();
			StaticVariables.AntidotePotionCreatedSound = false;
			Object temp = Instantiate(AntidotePotion,transform.position,transform.rotation);
			Destroy(temp,3.0f);
			bottle.color = Color.green;
			
		}
		if(StaticVariables.AgilityPotionCreatedSound){
			pelicanSound.Play ();
			StaticVariables.AgilityPotionCreatedSound = false;
			Object temp = Instantiate(AgilityPotion,transform.position,transform.rotation);
			Destroy(temp,3.0f);
			bottle.color = Color.cyan;
			
		}
		   if(StaticVariables.SalvePotionCreatedSound){
			
			pelicanSound.Play ();
			StaticVariables.SalvePotionCreatedSound = false;
			Object temp = Instantiate(SalvePotion,transform.position,transform.rotation);
			Destroy(temp,3.0f);
			bottle.color = Color.yellow;
		}
		   if(StaticVariables.PomadePotionCreatedSound){
			pelicanSound.Play ();
			StaticVariables.PomadePotionCreatedSound = false;
			Object temp = Instantiate(PomadePotion,transform.position,transform.rotation);
			Destroy(temp,3.0f);
			bottle.color = Color.magenta;
			
		}
		   if(StaticVariables.LaxativePotionCreatedSound){
			
			pelicanSound.Play ();
			StaticVariables.LaxativePotionCreatedSound = false;
			Object temp = Instantiate(LaxativePotion,transform.position,transform.rotation);
			Destroy(temp,3.0f);
			bottle.color = new Color32(79,26,66,255);

		}
	
	}
}
