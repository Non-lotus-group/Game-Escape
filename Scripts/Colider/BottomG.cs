using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomG : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerManager>().AbleJump = true;
            collision.gameObject.GetComponent<PlayerManager>().PlayerRigidBody.gravityScale = 1;
            Physics2D.gravity = new Vector2(0, -9.8f);
            collision.gameObject.GetComponent<PlayerManager>().transform.rotation = Quaternion.Euler(0, 0, 0);
            collision.gameObject.GetComponent<PlayerManager>().JumpResetTime = 4;
        }

    }
}
