using UnityEngine;
using System.Collections;

public class Left_Arm_Rotation : MonoBehaviour {

	Vector2 CurrentRotation = new Vector2(-1.0f,0.0f);
	Vector2 ApproachingRotation = new Vector2(0.0f,0.0f);
	Vector2 TravelRotation = new Vector2(0.0f,0.0f);
	public float RotationSpeed = 1.0f;
	public Vector3 LeftArmOffset = new Vector3(0,0,0);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		//transform.Rotate (0.0f,transform.right.x*Input.GetAxis ("Horizontal"),0.0f);


		if ((Mathf.Abs (Input.GetAxis ("Horizontal")) > 0.2f)||(Mathf.Abs (Input.GetAxis ("Vertical")) > 0.2f)) {
			if(Input.GetAxis ("Horizontal")>0.2f){
				ApproachingRotation.x = 1.0f;
			}
			if(Input.GetAxis ("Horizontal")<-0.2f){
				ApproachingRotation.x = -1.0f;
			}
			if(Input.GetAxis ("Vertical")>0.2f){
				ApproachingRotation.y = 1.0f;
			}
			if(Input.GetAxis ("Vertical")<-0.2f){
				ApproachingRotation.y = -1.0f;
			}
			ApproachingRotation.Normalize();

			TravelRotation.x = ApproachingRotation.x - CurrentRotation.x;
			TravelRotation.y = ApproachingRotation.y - CurrentRotation.y;
			if(TravelRotation.magnitude<RotationSpeed*Time.deltaTime)
				CurrentRotation = ApproachingRotation;
			else{
				TravelRotation.Normalize ();
				CurrentRotation += new Vector2(TravelRotation.x*RotationSpeed*Time.deltaTime,TravelRotation.y*RotationSpeed*Time.deltaTime);
			}
			//transform.localEulerAngles = new Vector3(-90*CurrentRotation.y,0,90+90*CurrentRotation.x);
			transform.localEulerAngles = new Vector3(-90*CurrentRotation.y,0,90+90*CurrentRotation.x)+LeftArmOffset;

			//transform.localEulerAngles = new Vector3(transform.localEulerAngles.x+Input.GetAxis ("RotationX"), transform.localEulerAngles.y+Input.GetAxis ("Vertical"),transform.localEulerAngles.z+Input.GetAxis("Horizontal"));
			//transform.Rotate (Input.GetAxis ("RotationX"),Input.GetAxis ("Vertical"),Input.GetAxis ("Horizontal"));

			Debug.Log ("CurrentRotation");
			Debug.Log(CurrentRotation);
			Debug.Log ("localRotation xyz");
			Debug.Log (transform.localRotation.x);
			Debug.Log (transform.localRotation.y);
			Debug.Log (transform.localRotation.z);
		}
		
	}
}
