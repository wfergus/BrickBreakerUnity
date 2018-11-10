﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Vector2 direction = new Vector2(); //direction the will influence player
	public Vector2 keyDirection;
	public bool IsKeyDown
	{
		get
		{
			if (keyDirection.sqrMagnitude == 0) return false;
			return true;
		}
	}


	public bool RestrainY, RestrainX;

	public PlayerController()
	{

	}

	void Awake()
	{
		keyDirection = new Vector2();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		keyDirection.x = keyDirection.y = 0;
		if (!RestrainX)
		{
			if (Input.GetKey("right"))
			{
				keyDirection.x += 1;
			}
			if (Input.GetKey("left"))
			{
				keyDirection.x += -1;
			}
		}
		if (!RestrainY)
		{
			if (Input.GetKey("up"))
			{
				keyDirection.y += 1;
			}
			if (Input.GetKey("down"))
			{
				keyDirection.y += -1;
			}
		}
		direction += keyDirection;
		direction.Normalize();
	}
}
