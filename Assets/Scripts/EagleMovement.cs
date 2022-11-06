using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleMovement : MonoBehaviour
{
    public float moveSpeed;

    public float boundary = -11f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if(transform.position.x < boundary)
        {
           Destroy(this.gameObject);
        }
    }

    void Movement()
    {
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed, Space.World);
    } 
}
