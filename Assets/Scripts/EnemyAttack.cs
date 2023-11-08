using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    private Animator animator;
    public Collision2D colisionPoint;
    Transform player;
    //Transform enemy;
    private float attackDistance = 2f;
    private float minDistance;
    private float rangeFromPlayer;
    private float _timerToAttack = 2f;
    private float _time = 1f;
    private float attackRate = 2f;
    public HeroKnight heroScript;
    public float cooldown = 1f;
    private float lastAttackedAt = -9999f;
    private bool s_grounded = false;

    void Start()
    {
        player = GameObject.Find("HeroKnight").transform;
        //enemy = GameObject.Find("Enemy").transform;
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        rangeFromPlayer = Vector3.Distance(transform.position, player.position);
        JumpAttack();
        //minDistance = (player.position - transform.position);
        //if (rangeFromPlayer <= attackDistance)
        //{
        //    if (Time.time > lastAttackedAt + cooldown)
        //    {
        //        JumpAttack();
        //        lastAttackedAt = Time.time;
        //    }

        //    //heroScript.TakeDamage(1);
        //    //if (attackRate >= _timerToAttack)
        //    ////if (_timerToAttack > 0)
        //    //{
        //    //    //_timerToAttack -= _time * Time.deltaTime;
        //    //    _timerToAttack = Time.deltaTime * 5f;
        //    //    animator.SetTrigger("Jump");

        //    //}
        //    //else
        //    //{
        //    //    _timerToAttack -= Time.deltaTime;
        //    //    //animator.SetTrigger("Jump");
        //    //    heroScript.TakeDamage(1);
        //    //    //yield new WaitForSeconds(seconds);
        //    //    //_timerToAttack = 3f;
        //    //    //Task.Delay(2000);
        //    //}
        //    //if (colisionPoint.gameObject.name == "HeroKnight") //out HeroKnight playercomponent
        //    //{
        //    //enemycomponent.TakeDamage(1);
        //    //transform.Translate(transform.position.x - 1,0,0);

        //    //}
        //}
    }
    //void DamagePlayer()
    //{
    //    //rangeFromPlayer = Vector3.Distance(transform.position, player.position);
    //    //minDistance = (player.position - transform.position);
    //    if (rangeFromPlayer == attackDistance)
    //    {
    //        if (_timerToAttack > 0)
    //        {
    //            _timerToAttack -= _time * Time.deltaTime;
    //        }
    //        else
    //        {
    //            animator.SetTrigger("Jump");
    //            heroScript.TakeDamage(1);
    //        }
    //        //if (colisionPoint.gameObject.name == "HeroKnight") //out HeroKnight playercomponent
    //        //{
    //        //enemycomponent.TakeDamage(1);
    //        //transform.Translate(transform.position.x - 1,0,0);

    //        //}
    //    }

    //}

    void JumpAttack()
    {
        s_grounded = true;
        animator.SetBool("Grounded", s_grounded);
        //if (colisionPoint.gameObject.name == "HeroKnight") //out HeroKnight playercomponent
        //{
        //    //enemycomponent.TakeDamage(1);
        //    animator.SetTrigger("Jump");
        //    heroScript.TakeDamage(1);
        //}
        if (rangeFromPlayer <= attackDistance)
        {
            if (Time.time > lastAttackedAt + cooldown)
            {
                animator.SetTrigger("Jump");
                lastAttackedAt = Time.time;
            }
        }
        if (animator.GetBool("Grounded"))
        {
            heroScript.TakeDamage(1);
        }
        //could try to damage if emeny is grounded
        //CHECK: https://forum.unity.com/threads/improving-ia-jump-towards-the-player.151424/
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        colisionPoint = collision;
        //JumpAttack();
    }
}