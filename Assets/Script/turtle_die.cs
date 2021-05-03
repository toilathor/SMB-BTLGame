using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtle_die : MonoBehaviour
{
    Vector2 VT2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VT2 = transform.localPosition;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "MyPlayer" && collision.contacts[0].normal.y < 0)
        {
            Destroy(gameObject);
            GameObject death = (GameObject)Instantiate(Resources.Load("Prefabs/turtle_death"));
            death.transform.localPosition = VT2;
        }
       // print(collision.contacts[0].normal.y);
    }
}
