using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float enemyMoveSpeed = 4f;

    private int enemyAttackValue = 1;
    
    // Update is called once per frame
    void Update()
    {
        Move();
    }
    
    private void Move(){
        
        if (transform.position.y < -10f) gameObject.transform.position = new Vector3(Random.Range(-4.9f, 4.9f), 6, 0);
        
        gameObject.transform.Translate(Time.deltaTime * enemyMoveSpeed * Vector3.down);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player =  other.GetComponent<Player>();

            if (player != null)
            {
                player.DamagePlayerByX(enemyAttackValue);   
            }
            else
            {
                Debug.LogError("Player object has no Player script attached!!");
            }
                
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
