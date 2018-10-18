using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {

    [SerializeField] private int damage = 25;
    [SerializeField] private bool spin = false;

    private int spinSpeed = 360;

    private void Update()
    {
        // TODO Move spinning to a more appropiate class
        if (spin)
        {
            transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
        }
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // TODO Improve inheritance or interface to apply damage to both enemy and player
        Enemy enemy = collider.GetComponent<Enemy>();
        if (enemy != null)
            collider.GetComponent<Enemy>().TakeHit(damage);
        Player player = collider.GetComponent<Player>();
        if (player != null)
            collider.GetComponent<Player>().TakeHit(damage);
        
        Destroy(gameObject);
    }

}
