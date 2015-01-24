using UnityEngine;
using System.Collections;

public class HeadFollowing : MonoBehaviour {
	public Transform headTransform;
	float timePassed=0.0f;
	bool warp=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timePassed+=Time.deltaTime;
		if(timePassed>2.0f){
			warp = true;
		}
		if(warp)
			transform.localPosition = headTransform.localPosition+new Vector3(-0.9203f,0,0);
	}
}
