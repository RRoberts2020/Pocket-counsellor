using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
	public float JumpForce = 5f;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.relativeVelocity.y <= 0f)
		{
			Rigidbody2D Rb = collision.gameObject.GetComponent<Rigidbody2D>();

			if (Rb != null)
			{
				Vector2 velocity = Rb.velocity;
				velocity.y = JumpForce;
				Rb.velocity = velocity;
			}
		}
	}
}
