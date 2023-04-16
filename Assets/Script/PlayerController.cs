using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float runSpeed;
	public float jumpPower;
	public Animator anim;


	private Rigidbody2D rb;
	private bool isRight =true;
	private float moveHor;
	private float moveVer;
	[SerializeField] private Transform GroundCheck;
	[SerializeField] private LayerMask groundLayer;
	[SerializeField] private GameObject GameControll;
	private GameController gc ;

	[SerializeField] private AudioSource footstep;
	[SerializeField] private AudioSource collect;
	[SerializeField] private AudioSource jump;
	[SerializeField] private AudioSource kill;
	[SerializeField] private AudioSource collide;
	[SerializeField] private AudioSource shot;


	[SerializeField] private GameObject bullet;
	[SerializeField] private Transform bulletSp;
	private bool isClimb;
	private bool isLadder;


	
    public float fireRate;
	private float timeRate = 0.5f;
	

    void Start(){
		rb = GetComponent<Rigidbody2D>();
        gc = GameControll.GetComponent<GameController>();
    }
	
	private void OnCollisionEnter2D(Collision2D other){
		
        if(other.gameObject.tag == "Enemy" && anim.GetBool("isJump")){
			EnemyController enemyControl = other.gameObject.GetComponent<EnemyController>();
			enemyControl.Dead();
			rb.velocity = new Vector2(rb.velocity.x,jumpPower);
			anim.SetBool("isJump",true);
			kill.Play();
        }
		if(other.gameObject.tag == "Enemy" && !anim.GetBool("isJump")){
			gc.reduceHealth();
			anim.SetBool("isHurt",true);
			collide.Play();
		}

		if(other.gameObject.tag == "Diamond"){
			Destroy(other.gameObject);
			gc.countDia();
			collect.Play();
		}
	}
	void OnCollisionExit2D(Collision2D other){
		if(other.gameObject.tag == "Enemy"){
			anim.SetBool("isHurt",false);
		}
	}


    void Update()
    {
		//movement
		moveHor = Input.GetAxisRaw("Horizontal") * runSpeed;
		
		if(Input.GetButtonDown("Jump") && isGrounded()){
			rb.velocity = new Vector2(rb.velocity.x,jumpPower);
			anim.SetBool("isJump",true);
			jump.Play();
		}

		if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f){
			rb.velocity = new Vector2(rb.velocity.x,rb.velocity.y*0.5f);
			anim.SetBool("isJump",true);
		}

		if(isGrounded()){
			anim.SetBool("isJump",false);
		}
	   	Flip();
	   
	   	//Fire
		if(Input.GetButton("Fire1") && Time.time>timeRate){
			timeRate = Time.time + fireRate;
			GameObject b = Instantiate(bullet);
			b.GetComponent<Bullet>().Move(isRight);
			b.transform.position = bulletSp.transform.position;
			shot.Play();
		}

	
	}

    void FixedUpdate(){
		//movement
		rb.velocity = new Vector2(moveHor, rb.velocity.y);
		anim.SetFloat("speed",Mathf.Abs(moveHor));


    }

	public bool isGrounded(){
		return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, groundLayer);
	}

	void Flip(){
		if(isRight && moveHor<0f || !isRight && moveHor>0f){
			isRight = !isRight;
			Vector3 localScale = transform.localScale;
			localScale.x *= -1f;
			transform.localScale = localScale;
		}
	}

	void FootStep(){
		footstep.Play();
	}

}
