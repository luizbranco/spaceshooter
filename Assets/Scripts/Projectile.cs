﻿using UnityEngine;
using System.Collections;

// Class responsible to handle projectile collisions, animations and its lifecycle
public class Projectile : Entity {

	public float speed = 5f;
	public string target;
	
	// Destroy projectile if it is out of camera bounds
	private void Update () {
		if (!gameObject.renderer.isVisible) {
			Destroy(this.gameObject);
		}
		transform.Translate(Vector2.up * speed * Time.deltaTime);
	}

	// Do and take damage when colliding to target
	private void OnTriggerEnter2D (Collider2D coll) {
		if (coll.tag == target) {
			coll.GetComponent<Entity>().TakeDamage(1);
			TakeDamage(1);
		}
	}

	// Destroy self
	override public void Kill () {
		Destroy(this.gameObject);
	}

}
