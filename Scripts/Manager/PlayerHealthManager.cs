using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public float PlayerHealth;
    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth = 200f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBallet") {
            float DisHp = collision.GetComponent<EnemyBullet1>().AttackValue;
            PlayerHealth = PlayerHealth - DisHp;
            Debug.Log(PlayerHealth);
        }

        
    }
}
