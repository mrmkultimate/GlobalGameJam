using UnityEngine;
using System.Collections;

public class Laxative : MonoBehaviour {

	public MeshRenderer meshRenderer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(StaticVariables.LaxativePotionCreated == true){
			meshRenderer.enabled = true;
		}else{
			meshRenderer.enabled = false;
		}
	}
}
