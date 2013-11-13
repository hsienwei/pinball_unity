using UnityEngine;
using System.Collections;

public class CollosionCallback : MonoBehaviour {
	public Main main = null;
	public string sendTag = null;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnTriggerEnter(Collider other) {
		Debug.Log("CollosionCallback " + sendTag);
		main.send(sendTag);
	}
	
	void OnCollisionEnter(Collision collision) {
		Debug.Log("CollosionCallback " + sendTag);
		main.send(sendTag);
	}
}
