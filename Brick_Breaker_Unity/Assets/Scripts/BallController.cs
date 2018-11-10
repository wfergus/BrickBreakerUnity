﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public Vector2 Direction;
	public float Speed;


	private Rigidbody2D rb2D;
	private SpriteRenderer spriteRenderer;

	void Awake()
	{
		spriteRenderer = this.GetComponent<SpriteRenderer>();
		Util.GetComponentIfNull(this, ref spriteRenderer);
		rb2D = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
	void FixedUpdate()
	{
		if (rb2D != null)
		{

			//Keep on screen
			this.rb2D.position = Util.BounceOffWalls(this.transform.position,
				spriteRenderer.bounds.size.x - 1,
				spriteRenderer.bounds.size.y - 1, ref this.Direction);
		}

		rb2D.MovePosition(rb2D.position + Direction * Speed * Time.fixedDeltaTime);
	}
	public void RelfectY()
	{
		this.Direction.y *= -1;
	}

	public void RelfectX()
	{
		this.Direction.x *= -1;
	}
}
