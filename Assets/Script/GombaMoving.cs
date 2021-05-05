using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GombaMoving : MonoBehaviour
{

    private float maxMove = 3f;
    private float locDefault;
    private bool nguoc = true;
    public bool isMove = true;
    private Animator anim;

    void Start()
    {
        locDefault = gameObject.transform.position.x;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove == true)
        {
            if (nguoc == true)
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
    }

    private void doiChieu()
    {
        if (gameObject.transform.position.x < locDefault - maxMove / 2)
        {
            nguoc = false;
        }
        else if (gameObject.transform.position.x > locDefault + maxMove / 2)
        {
            nguoc = true;
        }

    }
}
