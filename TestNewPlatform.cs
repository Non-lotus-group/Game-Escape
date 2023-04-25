using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNewPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            RaycastHit2D hit = Physics2D.Raycast(collision.transform.position, -transform.up);
            if (hit)
            {
                Vector2 normal = hit.normal;
                Vector2 tangent = new Vector2(normal.y, -normal.x);
                Vector2 direction = Input.GetAxisRaw("Horizontal") * tangent;
                rb.velocity = direction.normalized * 5f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
