using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    // Start is called before the first frame update

    public int spinny;
    
    void Start()
    {
        PolygonCollider2D colide = GetComponent<PolygonCollider2D>();
        ContactFilter2D filter = new ContactFilter2D().NoFilter();
        List<Collider2D> results = new List<Collider2D>();
        if (colide.OverlapCollider(filter, results) > 0 && !SelectStage.chaos)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject player = collision.gameObject;
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.AddForce(spinny * (this.transform.position - player.transform.position));
    }
}
