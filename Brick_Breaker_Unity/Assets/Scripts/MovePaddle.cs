﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MovePaddle : MonoBehaviour {

	public Vector2 Direction;
	public float Speed;

	private Vector3 moveTranslation;
	private Rigidbody2D rb2D;
	SpriteRenderer spriteRenderer;
	PlayerController playerController;

	void Awake()
	{
		Util.GetComponentIfNull(this, ref spriteRenderer);
		rb2D = GetComponent<Rigidbody2D>();
		playerController = GetComponent<PlayerController>();
		if (playerController == null)
		{
			playerController = this.gameObject.AddComponent<PlayerController>();
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playerController.IsKeyDown)
		{
			this.Direction = playerController.direction;
		}
		else
		{
			this.Direction = Vector3.zero;
		}
	
		if (rb2D != null)
		{
			this.rb2D.position = Util.BounceOffWalls(this.transform.position,
				spriteRenderer.bounds.size.x - 1,
				spriteRenderer.bounds.size.y - 1, ref this.Direction);
		}
	}
	void FixedUpdate()
	{
		rb2D.MovePosition(rb2D.position + Direction * Speed * Time.fixedDeltaTime);
	}
}
