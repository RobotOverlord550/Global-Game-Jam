using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CircleCollider2D colide = GetComponent<CircleCollider2D>();
        ContactFilter2D filter = new ContactFilter2D().NoFilter();
        List<Collider2D> results = new List<Collider2D>();
        if (colide.OverlapCollider(filter, results) > 0)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject player = collision.gameObject;
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.AddForce(-400 * (this.transform.position - player.transform.position));
    }
}
