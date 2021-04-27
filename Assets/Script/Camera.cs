using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            Vector3 pos = transform.position;
            pos.x = player.position.x + 4f;
            transform.position = pos;
        }
    }
}
