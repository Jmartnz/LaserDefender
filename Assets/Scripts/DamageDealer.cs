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
        IDamageReceiver damageReceiver = collider.GetComponent<IDamageReceiver>();
        damageReceiver?.TakeHit(damage);
        Destroy(gameObject);
    }

}
