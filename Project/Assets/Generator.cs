using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {
	public GameObject SaltPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Instantiate(SaltPrefab);
	}
}
