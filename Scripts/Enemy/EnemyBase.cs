using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public GameObject Player;
    public float MoveSpeed;
    public float DetectionRange;
    public float AttackDamage;
    public float AttackCoolDown;
    public float Health;
    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        
    }

    public virtual void Move() {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBallet") {
            Health = Health - 10;
            Debug.Log(Health);
        }
    }

}
