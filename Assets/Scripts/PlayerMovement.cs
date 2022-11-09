using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float m_MoveSpeed = 8f;
    public float m_JumpForce = 16f;
    public int m_MaxHealth = 100;
    public int m_CurrentHp;
    public int m_FightForce = 15;
    public bool m_isDead;

    public HeartBar m_healthBar;

    private float horizontal;
    private bool m_isGrounded;
    private bool m_isFacingRight = true;
    private float strength = 16;
    private float m_GetHitTime = 0.15f;
    private bool m_GetHit;

    PlayerController m_PlayerAnim;

    [SerializeField] private Rigidbody2D m_rb;
    [SerializeField] private Transform m_groundCheck;
    [SerializeField] private LayerMask m_groundLayer;

    GameManager m_GameManager;

    private void Start()
    {
        m_CurrentHp = m_MaxHealth;
        m_GameManager = GetComponent<GameManager>();
        m_PlayerAnim = GetComponent<PlayerController>();
        m_healthBar.SetMaxHealth(m_MaxHealth);
        m_isDead = false;
    }

    private void Update()
    {
        m_GetHitTime -= Time.deltaTime;
        if (m_GetHitTime <= 0)
            m_GetHit = false;
        
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("HorizontalPlayer1");
        MovementP1();
        Flip();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (m_GetHit) return;
        if (collision.CompareTag("Fight"))
        {
            m_GetHit = true;
            m_CurrentHp -= m_FightForce;
            m_healthBar.SetHealth(m_CurrentHp);
            Vector2 direction = (transform.position - collision.transform.position).normalized;
            m_rb.AddForce(strength * direction, ForceMode2D.Impulse);
        }

        if (m_CurrentHp <= 0)
        {
            m_isDead = true;

            new WaitForSeconds(5f);
            SceneManager.LoadScene("SampleScene");

            //Destroy(gameObject);
            Debug.Log("Player 1 da chet");
        }
    }

    private void MovementP1()
    {
        if (Input.GetButton("JumpP1") && IsGrounded())
        {
            m_PlayerAnim.PlayJumpAnim();
            m_rb.velocity = new Vector2(m_rb.velocity.x, m_JumpForce);
        }   else 
                if (Input.GetButton("FightP1") && IsGrounded()) {
                                         m_PlayerAnim.PlayAttackAnim();
                                                                }
                  
                                else if (horizontal != 0 && IsGrounded())
                                     {
                                         m_PlayerAnim.PlayRunAnim();
                                        }
                            else if (horizontal == 0 && IsGrounded())
                                m_PlayerAnim.PlayIdleAnim();


        m_rb.velocity = new Vector2(horizontal * m_MoveSpeed, m_rb.velocity.y);


    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(m_groundCheck.position, 0.2f, m_groundLayer);
    }

    private void Flip()
    {
        if (m_isFacingRight && horizontal < 0f || !m_isFacingRight && horizontal > 0f)
        {
            
            m_isFacingRight = !m_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    private void Hit()
    {
            m_PlayerAnim.PlayAttackAnim();       
    }

}
