using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;
    public float moveSpeed;
    private float boundary = -11f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed, Space.World);
        if(transform.position.x < boundary)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            ScoreManager.coin++;
            ScoreManager.ScoreSet(value);
            Destroy(this.gameObject);
        }
    }
}
