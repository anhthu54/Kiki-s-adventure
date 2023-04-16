using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float TimeDestroy;

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag=="Enemy"){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    public void Move(bool isRight)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if(isRight){
            rb.velocity = new Vector2(speed,0);
        }
        else if(!isRight){
            rb.velocity = new Vector2(-speed,0);
        }
        Destroy(gameObject,TimeDestroy);
    }

}
