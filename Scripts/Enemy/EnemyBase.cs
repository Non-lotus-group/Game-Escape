using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
    public GameObject Player;
    public float MoveSpeed;
    public float DetectionRange;
    public float AttackDamage;
    public float AttackCoolDown;
    public float Health;
    public GameObject Bullet;
    public Slider HealthSlider;
    public float MaxHealth;
    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        MaxHealth = 100f;
        Health = 100f;
        HealthSlider = GetComponentInChildren<Slider>();
       
    }

    private void Update()
    {
        HealthSlider.value = Health / MaxHealth;
        SelfDestory();
    }

    public virtual void Move()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBallet")
        {
            SwordAttack Sward = collision.gameObject.GetComponent<SwordAttack>();
            if (Sward != null)
            {
                float AttackValue = Sward.AttackValue;
                Health = Health - AttackValue;
            }
            else
            {
                Debug.Log(collision.name);
            }

        }
    }
    void SelfDestory()
    {
        if (Health < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
