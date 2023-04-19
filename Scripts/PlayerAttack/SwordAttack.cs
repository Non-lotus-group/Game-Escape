using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Rigidbody2D SwordRigid;
    public Vector2 ThisPos;
    public float AttackValue;
    public float AttackRange;
    private void Start()
    {
        SwordRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SwordRigid.velocity = transform.right * 10f;
        ThisPos = this.transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Recycler") && other.GetComponent<BoxCollider2D>() != null)
        {
            Destroy(gameObject);
        }
    }
}
