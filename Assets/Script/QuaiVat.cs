using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaiVat : MonoBehaviour
{
    private float maxMove = 3f;
    private float locDefault;
    private bool nguoc = true;

    // Start is called before the first frame update
    void Start()
    {
        locDefault = gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(nguoc == true)
        {
            gameObject.transform.Translate(Vector2.left * maxMove * Time.deltaTime);
            doiChieu();
        }
        else
        {
            gameObject.transform.Translate(Vector2.right * maxMove * Time.deltaTime);
            doiChieu();
        }


    }

    private void doiChieu()
    {
        if (gameObject.transform.position.x < locDefault - maxMove/2)
        {
            nguoc = false;
        }
        else if (gameObject.transform.position.x > locDefault + maxMove / 2)
        {
            nguoc = true;
        }
    }
}
