using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public Vector2 directionToMove;
    [Header("Lifetime")]
    public float lifeTime;
    private float lifeTimeSeconds;
    public Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        lifeTimeSeconds = lifeTime;

    }

    // Update is called once per frame
    void Update()
    {
        lifeTimeSeconds -= Time.deltaTime;
        if (lifeTimeSeconds <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void Launch(Vector2 initialDirection)
    {
        myRigidBody.velocity = initialDirection * moveSpeed;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.isTrigger)
        Destroy(this.gameObject);
    }
}
