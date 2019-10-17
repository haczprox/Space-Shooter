using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float laserMoveSpeed = 5f;

    public float GetLaserHeight()
    {
        RectTransform rt = (RectTransform) gameObject.transform;

        return rt.rect.height;
    }
    
    void Update() 
    {
        MoveOrDestroy();
    }

    private void MoveOrDestroy()
    {
        if (transform.position.y >= 4.9f) Destroy(gameObject);
        
        gameObject.transform.Translate(Time.deltaTime * laserMoveSpeed * Vector3.up);
    }
}
