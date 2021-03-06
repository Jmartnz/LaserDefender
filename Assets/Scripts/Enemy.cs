﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageReceiver {

	[SerializeField] private int health = 100;
    [SerializeField] private int points = 100;
	[SerializeField] private GameObject proyectile;
	[SerializeField] private float proyectileSpeed = 15.0f;
	[SerializeField] private int proyectileDamage = 25;
	[SerializeField] private float minTimeBetweenShoots = 0.5f;
	[SerializeField] private float maxTimeBetweenShoots = 3.0f;
	[SerializeField] private AudioClip fireSound;
	[SerializeField] private AudioClip deathSound;
	[SerializeField] private GameObject explosionParticle;

	// Use this for initialization
	void Start () {
		StartCoroutine(ShootAndWait());
	}

	IEnumerator ShootAndWait()
	{
		while (health > 0)
		{
			float timeBetweenShots = Random.Range(minTimeBetweenShoots, maxTimeBetweenShoots);
			yield return new WaitForSeconds(timeBetweenShots);
			Shoot();
		}
	}

	private void Shoot()
	{
		AudioSource.PlayClipAtPoint(fireSound, transform.position, 1.0f);
		GameObject laserInstance = Instantiate(proyectile, transform.position, Quaternion.identity);
		laserInstance.GetComponent<DamageDealer>().SetDamage(proyectileDamage);
		laserInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -proyectileSpeed);
	}

	public void TakeHit(int damage)
	{
		health -= damage;
		if (health <= 0) Die();
	}

	private void Die()
	{
		AudioSource.PlayClipAtPoint(deathSound, transform.position, 1.0f);
		GameObject explosion = Instantiate(explosionParticle, transform.position, Quaternion.identity);
		Destroy(explosion, 1.0f);
        FindObjectOfType<LevelManager>().AddToScore(points);
		Destroy(gameObject);
	}

}
