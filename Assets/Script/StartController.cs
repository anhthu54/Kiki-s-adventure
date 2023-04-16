using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    [SerializeField] private AudioSource footstep;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "block"){
            SceneManager.LoadScene("level1");
        }
    }


    public void PlayGame(){
        anim.SetBool("isRun",true);
        rb.velocity = new Vector2(8.0f,0.0f);
    }

    void FootStep(){
		footstep.Play();
	}
}
