using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {
	// Use this for initialization
	public Ball[] _balls ;
	private int curIdx = 0;
	
	private Vector3 ballInitPos = new Vector3(-6.944683f, 3.566466f, -0.1087482f);
	//private Vector3 controlInitPos = new Vector3(-14.16732f, 4.28203f, -0.1151695f);
	
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		/*Animator animator  = gameObject.GetComponent<Animator>();
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
		if(stateInfo.nameHash == Animator.StringToHash("ControlLayer.push") &&
			animator.GetBool("isPush"))
		{
			animator.SetBool(Animator.StringToHash("isPush"), false);
		}*/
			
		//this.transform.position = controlInitPos;
	}
	
	public void push(int power)
	{
    /*Animator animator  = gameObject.GetComponent<Animator>();
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
		
		if(stateInfo.nameHash == Animator.StringToHash("ControlLayer.idle"))
		{
			animator.SetBool(Animator.StringToHash("isPush"), true);
				
			if(_balls[curIdx] != null)
			{
				_balls[curIdx].fire(power);
			}
			curIdx++;
		}*/
    //Animation animation  = gameObject.GetComponent<Animation>();
    //animation.Play("push2");
    Animator animator = gameObject.GetComponent<Animator>();
    animator.SetTrigger("move");

    if (_balls[curIdx] != null)
		{
			_balls[curIdx].fire(power);
		}
		
	}
	
	public void nextBall()
	{
		curIdx++;
	}
	
	public void setBall()
	{
		_balls[curIdx].transform.position = ballInitPos;
		_balls[curIdx].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
	}
	
	public bool isEnd()
	{
		return curIdx >= _balls.Length;
	}
	
	public void reset()
	{
		curIdx = 0;
	}
	
}
