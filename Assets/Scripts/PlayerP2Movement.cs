using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerP2Movement : MonoBehaviour
{
    public float m_MoveSpeed2 = 8f;
    public float m_JumpForce2 = 16f;
    public int m_CurrentHp;
    public int m_MaxHealth = 100;
    public int m_FightForce = 15;
    public bool m_isDead = false;


    public HeartBar m_healthBar;



    private float horizontal2;
    private bool m_isGrounded2;
    private bool m_isFacingRight2 = false;
    private float strength = 16;
    private float m_GetHitTime = 0.15f;
    private bool m_GetHit;

    PlayerController m_PlayerAnim2;

    [SerializeField] private Rigidbody2D m_rb2;
    [SerializeField] private Transform m_groundCheck2;
    [SerializeField] private LayerMask m_groundLayer2;

    GameManager m_GameManager;

    private void Start()
    {
        m_GameManager = GetComponent<GameManager>();
        m_PlayerAnim2 = GetComponent<PlayerController>();
        m_CurrentHp = m_MaxHealth;
        m_healthBar.SetMaxHealth(m_MaxHealth);
        
    }

    private void Update()
    {
        m_GetHitTime -= Time.deltaTime;
        if (m_GetHitTime <= 0)
            m_GetHit = false;
        

    }


    private void FixedUpdate()
    {
        horizontal2 = Input.GetAxisRaw("HorizontalPlayer2");
        MovementP2();
        Flip2();
        
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
            m_rb2.AddForce(strength * direction, ForceMode2D.Impulse);
        }

        if (m_CurrentHp <= 0)
        {
            m_isDead = true;

            new WaitForSeconds(5f);

            SceneManager.LoadScene("SampleScene");
            //Destroy(gameObject);
            Debug.Log("Player 2 da chet");
        }
        
    }
    
    private void KnockBack(GameObject sender)
    {
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        m_rb2.AddForce(strength * direction, ForceMode2D.Impulse);
    }

    private void MovementP2()
    {
        if (Input.GetButton("JumpP2") && IsGrounded2())
        {
            m_PlayerAnim2.PlayJumpAnim();
            m_rb2.velocity = new Vector2(m_rb2.velocity.x, m_JumpForce2);
        }
        else
                if (Input.GetButton("FightP2") && IsGrounded2())
        {
            m_PlayerAnim2.PlayAttackAnim();
        }

        else if (horizontal2 != 0 && IsGrounded2())
        {
            m_PlayerAnim2.PlayRunAnim();
        }
        else if (horizontal2 == 0 && IsGrounded2())
            m_PlayerAnim2.PlayIdleAnim();


        m_rb2.velocity = new Vector2(horizontal2 * m_MoveSpeed2, m_rb2.velocity.y);


    }

    private bool IsGrounded2()
    {
        return Physics2D.OverlapCircle(m_groundCheck2.position, 0.2f, m_groundLayer2);
    }

    private void Flip2()
    {
        if (m_isFacingRight2 && horizontal2 < 0f || !m_isFacingRight2 && horizontal2 > 0f)
        {

            m_isFacingRight2 = !m_isFacingRight2;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    private void Hit2()
    {
        m_PlayerAnim2.PlayAttackAnim();
    }

}
