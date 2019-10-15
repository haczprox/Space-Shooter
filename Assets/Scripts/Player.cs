using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField]  
    private float playerMoveSpeed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        // Set the Player starting position to (0, 0, 0)
        gameObject.transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 movementDirectionVector = new Vector3(horizontalInput, verticalInput, 0);
        gameObject.transform.Translate(Time.deltaTime * playerMoveSpeed * movementDirectionVector);
    }
}
