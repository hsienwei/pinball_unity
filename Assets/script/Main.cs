using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	//public RuntimeAnimatorController mainController = null;
	public Control control = null;
	public GameObject table = null;
	
	private float fireWaitTime = 0.0f;
	private float firePower = 0.0f;
	private bool  isPowerAdd = false;
	private bool  canFire = false;
	private int   ballDropCount= 0;
	
	enum GameState{
		INIT,
		READY,
		FIRE,
		BALL_SET,
		RESET,
		RESET2,
	};
	GameState _gameState = GameState.INIT;
	
	
	// Use this for initialization
	void Start () {
		 Time.fixedDeltaTime = 0.001f;
	}
	// Update is called once per frame
	void Update () {
		Animator animator;
		AnimatorStateInfo stateInfo;
		
		if(_gameState ==  GameState.INIT)
		{
		
			if(Input.GetMouseButtonUp(0))
			{
				if(control.isEnd())
				{
					_gameState = GameState.RESET;
					control.reset();
				}
				else
				{
					_gameState = GameState.BALL_SET;
				}
			}
		}
		else if(_gameState == GameState.READY) 
		{
			if(canFire)
			{
				if(Input.GetMouseButtonDown(0))
				{
					firePower = 0.0f;
					isPowerAdd = true;
				}
				if(isPowerAdd)
				{
					firePower += Time.deltaTime * 20;
					if(firePower > 100)    
						firePower = 0;
				}
					
				if(Input.GetMouseButtonUp(0))
				{
					control.push((int)firePower* 3);
					_gameState = GameState.FIRE;
					fireWaitTime = 0.0f;
					isPowerAdd = false;
					canFire= false;
				}
			}
		}
		else if(_gameState == GameState.BALL_SET)
		{
			control.setBall();
			_gameState = GameState.READY;
		}
		else if(_gameState ==  GameState.FIRE)
		{
		}
		else if(_gameState ==  GameState.RESET)
		{
			animator  = table.GetComponent<Animator>();
      animator.SetTrigger("open");
      ballDropCount = 0;
			_gameState = GameState.RESET2;
		}
		else if(_gameState ==  GameState.RESET2)
		{
		}
	}
	
	void OnGUI()
	{
		if(_gameState == GameState.READY)
		{
			  GUI.Label(new Rect(10, 10, 100, 20), "Power:" + (int)firePower);
		}
	}
	
	public void send(string tag)
	{
		if(_gameState == GameState.READY ||
			_gameState == GameState.FIRE) 
		{
			if(tag.Equals("ballInit"))
			{
				canFire = true;
				
				_gameState = GameState.READY;
			}
		}
		
		if(_gameState ==  GameState.FIRE)
		{
			if(tag.Equals("ballEnd"))
			{
				control.nextBall();
				_gameState = GameState.INIT;
				canFire = false;
			}
		}
		
		if(_gameState == GameState.RESET2)
		{
			if(tag.Equals("ballBack"))
			{
				ballDropCount++;
				if(ballDropCount > 9)
				{
					Animator animator  = table.GetComponent<Animator>();
					//stateInfo = animator.GetCurrentAnimatorStateInfo(0);
					animator.SetBool(Animator.StringToHash("isOpen"), false);
					_gameState = GameState.INIT;
				}
			}
		}
	}
	
}
