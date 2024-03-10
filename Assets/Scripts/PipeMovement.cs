using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    private bool started = false;
    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            started = true;
        }

        if (started)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (transform.position.x <= -3.5f)
        {
            transform.position = new Vector3(7.6f, Random.Range(-2.5f, 3f), 0f);
        }
    }
}
