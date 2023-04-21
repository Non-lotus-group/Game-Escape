using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet1 : MonoBehaviour
{
    public Rigidbody2D BulletRigidBody;
    public Vector2 ThisPos;
    public float AttackValue;
    public float AttackRange;
    // Start is called before the first frame update
    void Start()
    {
        BulletRigidBody = GetComponent<Rigidbody2D>();
        AttackValue = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        BulletRigidBody.velocity = transform.right * 10f;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Recycler") && other.GetComponent<BoxCollider2D>() != null)
        {
            Destroy(this.gameObject);
        }
    }
}
