using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle, 
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public int Health;
    public string EnemyName;
    public int BaseAttack;
    public float MoveSpeed;

    public void Knock(Rigidbody2D myRigidBody, float knockTime)
    {
        StartCoroutine(KnockCo(myRigidBody, knockTime));
    }

    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            myRigidbody.GetComponent<Enemy>().currentState = EnemyState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }
}
