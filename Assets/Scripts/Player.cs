﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private float moveSpeed = 15.0f;
    [SerializeField] private float padding = 1.0f;
    [SerializeField] private GameObject proyectile;
    [SerializeField] private float proyectileSpeed = 30.0f;
    [SerializeField] private float roundsPerSecond = 1.0f; // Fire rate


    Coroutine fireContinously;

    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

	// Use this for initialization
	void Start () {
        SetUpMoveBoundaries();
	}

    // Update is called once per frame
    void Update () {
        Move();
        if (Input.GetButtonDown("Fire1"))
        {
            fireContinously = StartCoroutine(FireContinously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fireContinously);
        }
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    private void Move()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x + deltaX, xMin, xMax),
            Mathf.Clamp(transform.position.y + deltaY, yMin, yMax)
        );
    }

    IEnumerator FireContinously()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(GetFireRateElapsedTime());
        }
    }

    private void Shoot()
    {
        GameObject laserInstance = Instantiate(proyectile, transform.position, Quaternion.identity);
        laserInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, proyectileSpeed);
    }

    private float GetFireRateElapsedTime()
    {
        return (1.0f / roundsPerSecond);
    }

}