using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainManaRegen : MagicPowerUp
{
    public Collider2D boundary;
    public GameObject player;
    public float regenDelay;
    private float regenelaySeconds;
    private bool canRegen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        regenelaySeconds -= Time.deltaTime;
        if (regenelaySeconds <= 0)
        {
            canRegen = true;
            regenelaySeconds = regenDelay;
        }
    }
    void FixedUpdate()
    {
        ManaRegen();
    }
    private void  ManaRegen()
    {
        if (boundary.bounds.Contains(player.transform.position)&&canRegen)
        {
            playerInventory.currentMagic += magicValue;
            powerupSignal.Raise();
            canRegen = false;
        }
        
    }
    public override void  OnTriggerEnter2D(Collider2D collision)
    {
        return;
    }

}
