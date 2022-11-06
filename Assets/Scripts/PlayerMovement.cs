using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioManager am;

    Rigidbody2D rb;
    Animator anim;
    CapsuleCollider2D cc;
    public Scene_Manager sc;
    public float moveSpeed = 5f;
    public float jumpSpeed = 5f;
    private bool isGround;
    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        cc = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && isGround)
        {
            anim.SetBool("isJumping",true);
            isGround = false;
            rb.velocity = new Vector2(0, jumpSpeed * moveSpeed);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Floor")
        {
            isGround = true;
            anim.SetBool("isJumping",false);
        }

        if(other.gameObject.tag == "Enemy")
        {
            StartCoroutine(PlayDeath());
            am.PlaySound("Collision");
        }

        if(other.gameObject.tag == "Collectables")
        {
            am.PlaySound("Collect1");
        }
    }

    public IEnumerator PlayDeath()
    {
        cc.enabled = false;
        rb.Sleep();
        am.PlaySound("Death");
        anim.SetTrigger("isDead");
        yield return new WaitForSeconds(1.5f);
        sc.OnGameOver();
        Destroy(gameObject);
    }
}