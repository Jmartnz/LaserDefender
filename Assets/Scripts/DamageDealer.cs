using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {

    [SerializeField] private bool hitsEnemies = true;
    [SerializeField] private int damage = 25;

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (hitsEnemies)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                collider.GetComponent<Enemy>().TakeHit(damage);
                Destroy(gameObject);
            }
        }
        else
        {
            Player player = collider.GetComponent<Player>();
            if (player != null)
            {
                collider.GetComponent<Player>().TakeHit(damage);
                Destroy(gameObject);
                Debug.Log("Hitting player!");
            }
        }
    }

}
