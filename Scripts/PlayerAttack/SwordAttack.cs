using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Rigidbody2D SwordRigid;
    public Vector2 ThisPos;
    public float AttackValue;
    private void Start()
    {
        SwordRigid = GetComponent<Rigidbody2D>();
        AttackValue = 45;
    }

    // Update is called once per frame
    void Update()
    {
        SwordRigid.velocity = transform.right * 10f;
        ThisPos = this.transform.position;
        if (ThisPos.x < -100 || ThisPos.x > 100)
        {
            Destroy(this.gameObject);
        }
    }
}
