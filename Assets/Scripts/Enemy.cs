using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] private int health = 100;
	[SerializeField] private GameObject proyectile;
	[SerializeField] private float proyectileSpeed = 15.0f;
	[SerializeField] private int proyectileDamage = 25;
	[SerializeField] private float minTimeBetweenShoots = 0.5f;
	[SerializeField] private float maxTimeBetweenShoots = 3.0f;
	[SerializeField] private AudioClip impactSound;
    [SerializeField] private GameObject explosionParticle;

    // Use this for initialization
    void Start () {
		StartCoroutine(ShootAndWait());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator ShootAndWait()
	{
		while (health > 0)
		{
			float timeToWait = Random.Range(minTimeBetweenShoots, maxTimeBetweenShoots);
			yield return new WaitForSeconds(timeToWait);
			Shoot();
		}
	}

	private void Shoot()
	{
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
        AudioSource.PlayClipAtPoint(impactSound, transform.position);
        GameObject explosion = Instantiate(explosionParticle, transform.position, Quaternion.identity);
        Destroy(explosion, 1.0f);
        Destroy(gameObject);
    }

}
