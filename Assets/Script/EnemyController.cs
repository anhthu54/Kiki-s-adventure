using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb ;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
    }

    void FixedUpdate(){
    }

    public void Dead(){
        anim.SetTrigger("Dead");
        rb.velocity = new Vector2(0,0);
    }

    void Death(){
        Destroy(gameObject);
    }

}
