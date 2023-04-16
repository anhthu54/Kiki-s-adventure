using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    [SerializeField] GameObject player;

    public float speed;
    
    private float distance;


    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if(player!=null && distance<6){
            Vector2 direction = player.transform.position - transform.position;    
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            if(transform.position.x<player.transform.position.x){
                transform.localScale = new Vector2(-5,5);
            }
            else{
                transform.localScale = new Vector2(5,5);
            }
        }
    }
}
