using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public MeshRenderer meshRenderer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(StaticVariables.HealthPotionCreated == true){
			meshRenderer.enabled = true;
		}else{
			meshRenderer.enabled = false;
		}
	}
}
