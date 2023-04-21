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
    public GameObject Gold;
    public GameObject Exp;
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
            int GoldNum = Random.Range(10, 20);
            int ExpNum = Random.Range(10, 20);
            for (int i = 0; i < GoldNum; i++)
            {
                // 在自身位置周围随机一个位置
                Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-8, 8), 5, 0);

                // 在随机位置实例化预制体
                Instantiate(Gold, spawnPosition, Quaternion.identity);
            }
            for (int i = 0; i < ExpNum; i++)
            {
                // 在自身位置周围随机一个位置
                Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-8, 8), 5, 0);

                // 在随机位置实例化预制体
                Instantiate(Exp, spawnPosition, Quaternion.identity);
            }
        }
    }
}
