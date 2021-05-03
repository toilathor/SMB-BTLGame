using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomped : MonoBehaviour
{
    public float force;
    bool stomed = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MyPlayer"))
        {
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
            playerRb.AddForce(Vector2.up * force);
            stomed = true;
            BoxCollider2D boxCollider2D = transform.parent.gameObject.GetComponent<BoxCollider2D>();
            boxCollider2D.enabled = false;

        }

    }
     void OnBecameInvisible()
    {
        if(stomed == true)
        {
            Destroy(transform.parent.gameObject);
        }
    }
    
}
