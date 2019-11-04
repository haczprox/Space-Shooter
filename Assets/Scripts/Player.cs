using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerMoveSpeed = 5f;
    [SerializeField] private GameObject laserPrefab = null;
    [SerializeField] private float laserCreationOffset = 0.75f;
    [SerializeField] private float rateOfFire = 0.15f;
    [SerializeField] private int numberOfLives = 5;

    private IEnumerator firingCooldownCoroutine;
    private bool isFiringOnCooldown = false;
    
    void Start()
    {
        gameObject.transform.position = Vector3.zero;
        numberOfLives = 5;
        
        firingCooldownCoroutine = StartFiringCooldown();
    }

    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootLaser();
        }
    }

    private IEnumerator StartFiringCooldown()
    {
        yield return new WaitForSeconds(rateOfFire);
        isFiringOnCooldown = false;
    }
    
    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirectionVector = new Vector3(horizontalInput, verticalInput, 0);
        gameObject.transform.Translate(Time.deltaTime * playerMoveSpeed * movementDirectionVector);

        var playerPosition= transform.position;
        transform.position = new Vector3(Mathf.Clamp(playerPosition.x, -9.2f, 9.2f), Mathf.Clamp(playerPosition.y, -4.9f, 4.9f), 0);
    }
    
    private void ShootLaser()
    {
        if (isFiringOnCooldown) return;
        
        isFiringOnCooldown = true;
        Instantiate(laserPrefab, transform.position + new Vector3(0, laserCreationOffset, 0), Quaternion.identity);
        firingCooldownCoroutine = StartFiringCooldown();
        StartCoroutine(firingCooldownCoroutine);
    }

    public void DamagePlayerByX(int damage)
    {
        numberOfLives -= damage;
        if (numberOfLives <= 0)
        {
            
        }
    }
}