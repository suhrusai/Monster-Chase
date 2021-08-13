using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    public float jumpForce = 11f;

    private float movementX;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;

    private Text PlayerLocationUI;
    bool isGrounded = true;
    private string GROUND_TAG = "Ground";
    private string WALK_ANIMATION = "Walk";
    private string ENEMY_TAG = "Enemy";
    


    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 1;
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        PlayerLocationUI = GameObject.Find(" Player Location Text").GetComponent<Text>();
        sr = GetComponent<SpriteRenderer>();
        //tm = (TextMesh)GameObject.Find("nameOfTheObject").GetComponent<TextMesh>();
        // here we change the value of displayed text
        
    }
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
        PlayerLocationUI.text = "X: " + Math.Round(transform.position.x,4) + "\nY: " + Math.Round(transform.position.y, 4);
    }

    void FixedUpdate()
    {

    }
    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
        
    }

    void AnimatePlayer()
    {
        if(movementX>0){
            sr.flipX = false;
            anim.SetBool(WALK_ANIMATION, true);
        }
        else if (movementX < 0)
        {
            sr.flipX = true;
            anim.SetBool(WALK_ANIMATION, true);
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }

    }
    
    void PlayerJump()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }
}
