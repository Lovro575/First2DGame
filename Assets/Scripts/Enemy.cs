using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;
    private Animator animator;
    Transform target;
    public float moveSpeed = 2f;
    private float minDistance = 2f;
    private float range;
    Rigidbody2D rb;
    Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        health = maxHealth;
        animator = this.GetComponent<Animator>();
        target = GameObject.Find("HeroKnight").transform;
    }

    void Update()
    {

        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //rb.rotation = angle;
            moveDirection = direction;
        }
        //range = Vector2.Distance(transform.position, target.position);

        //if (range > minDistance)
        //{
        //    Debug.Log(range);
        //    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        //}

        //range = Vector3.Distance(transform.position, target.position);

        //if (range > minDistance)
        //{
        //    //Debug.Log(range);
        //    //animator.SetTrigger("Jump");
        //    transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        //}
    }

    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
            //transform.Translate(Vector3.forward * moveSpeed);
        }
    }



    //public void JumpAttack()
    //{
    //    //range = Vector2.Distance(transform.position, target.position);

    //    if (range > minDistance)
    //    {
    //        Debug.Log(range);
    //        animator.SetTrigger("Jump");
    //        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    //    }
    //    /*
    //    if (range <= 2)
    //    {
    //        animator.SetTrigger("Jump");
    //    } */
    //}

    //AI CODE - enemy right bellow player

    //float health, maxHealth = 3f;
    //private Animator animator;
    //public Transform playerTransform;  // Reference to the player's Transform
    //public float moveSpeed = 3.0f;    // Speed at which the enemy follows the player

    //private void Start()
    //{
    //    // Find and store a reference to the player GameObject's Transform
    //    playerTransform = GameObject.FindWithTag("Player").transform;

    //    if (playerTransform == null)
    //    {
    //        Debug.LogError("Player GameObject not found with the 'HeroKnight' tag.");
    //    }
    //}

    //private void Update()
    //{
    //    if (playerTransform != null)
    //    {
    //        // Calculate the direction from the enemy to the player
    //        Vector3 direction = playerTransform.position - transform.position;

    //        // Normalize the direction vector to get a unit vector
    //        direction.Normalize();

    //        // Move the enemy towards the player
    //        transform.Translate(direction * moveSpeed * Time.deltaTime);
    //    }
    //}


    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        //animator.SetFloat("BlueHurt", health);
        animator.SetTrigger("Hurt");

        if (health <= 0)
        {
            animator.SetTrigger("Death");
            Destroy(gameObject, 0.7f);
        }
    }

}
