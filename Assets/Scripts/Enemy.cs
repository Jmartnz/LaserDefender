﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] private int health = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeHit(int damage)
    {
        health -= damage;
        if (health <= 0) Destroy(gameObject);
    }

}