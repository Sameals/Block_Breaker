using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    [SerializeField] float minY;
    private void Update()
    {
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }

}
