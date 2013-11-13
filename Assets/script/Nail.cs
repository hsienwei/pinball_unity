using UnityEngine;
using System.Collections;

public class Nail : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.GetComponent<Ball>() != null)
		{
			Rigidbody rigidbody = collision.gameObject.GetComponent<Rigidbody>();
			if(rigidbody)
			{
				Debug.Log("get rigidbody");
				//rigidbody.velocity = new Vector3(5, 5, 0);
			}
				
			Debug.Log("Nail collision Ball");
		}
	}
}
