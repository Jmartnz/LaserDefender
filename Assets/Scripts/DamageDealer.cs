using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {

    [SerializeField] private int damage = 25;

    public int GetDamage()
    {
        return damage;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(gameObject);
        Enemy enemy = collider.GetComponent<Enemy>();
        if (enemy != null) collider.GetComponent<Enemy>().TakeHit(damage);
    }

}
