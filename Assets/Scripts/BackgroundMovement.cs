using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    private bool started = false;
    public float speed = 1f;

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

        if (transform.position.x <= -22.95f)
        {
            transform.position = new Vector3(57.317f, 0, 10f);
        }
    }
}
