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
        Health = 100f;
    }

    private void Update()
    {
        
    }

    public virtual void Move() {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBallet") {
            SwordAttack Sward = collision.gameObject.GetComponent<SwordAttack>();
            Debug.Log("hit");
            if (Sward != null)
            {
                float AttackValue = Sward.AttackValue;
                Health = Health - AttackValue;
                Debug.Log(Health);
            }
            else {
                Debug.Log("not catch");
            }

        }
    }
    void SelfDestory() {
        if (Health < 0) {
            Destroy(this.gameObject);
        }
    }
}
