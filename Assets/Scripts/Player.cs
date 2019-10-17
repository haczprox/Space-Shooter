using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerMoveSpeed = 5f;

    [SerializeField] private GameObject laserPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        // Set the Player starting position to (0, 0, 0)
        gameObject.transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(laserPrefab, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
        }
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
}