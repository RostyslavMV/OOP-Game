﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Powerup
{
    public FloatValue playerHealth;
    public FloatValue heartContainers;
    public float amountToIncrease;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            playerHealth.RuntimeValue += amountToIncrease;
            if (playerHealth.RuntimeValue > heartContainers.RuntimeValue * 2)
            {
                playerHealth.RuntimeValue = heartContainers.RuntimeValue * 2;
            }
            powerupSignal.Raise();
            Destroy(this.gameObject);
        }
        
    }
}
