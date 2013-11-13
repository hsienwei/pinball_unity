using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collision) {
		//Debug.Log("a");
	}
	
	public void fire(int power)
	{
		Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
			if(rigidbody)
			{
				
				rigidbody.velocity = new Vector3(power * 2, 0, 0);
			}
	}
}
