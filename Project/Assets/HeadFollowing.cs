using UnityEngine;
using System.Collections;

public class HeadFollowing : MonoBehaviour {
	public Transform headTransform;
	public float timePassed=0.0f;
	public bool warp=false;
	public Vector3 offset;
	Vector3 startingPosition;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		timePassed+=Time.deltaTime;
		if((timePassed>2.0f)&&(!warp)){
			startingPosition = transform.position;
			warp = true;
		}
		if(warp){
			transform.position = headTransform.localPosition + startingPosition+offset;
		}
	}
}
