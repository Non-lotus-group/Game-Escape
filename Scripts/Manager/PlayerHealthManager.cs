using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public float PlayerHealth;
    public float MaxHealth;
    public Slider HealthSlider;
    // Start is called before the first frame update
    void Start()
    {
        HealthSlider = GetComponentInChildren<Slider>();
        PlayerHealth = 200f;
        MaxHealth = 200f;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth > 0)
        {
            HealthSlider.value = PlayerHealth / MaxHealth;
        }
        else {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ballet")
        {
            float DisHp = collision.GetComponent<EnemyBullet1>().AttackValue;
            PlayerHealth = PlayerHealth - DisHp;
        }


    }
}
