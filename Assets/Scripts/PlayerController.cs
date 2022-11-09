using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;

    private int m_Attack1Hash;
    private int m_IdleHash;
    private int m_RunHash;
    private int m_JumpHash;
    private int m_GuardHash;

    private void Start()
    {
        m_Attack1Hash = Animator.StringToHash("Attack1");
        m_IdleHash = Animator.StringToHash("Idle");
        m_RunHash = Animator.StringToHash("Run");
        m_JumpHash = Animator.StringToHash("Jump");
        //m_GuardHash = Animator.StringToHash("Guard");
    }


    [ContextMenu("Play Attack1 Anim")] 
    public void PlayAttackAnim()
    {
        m_Animator.SetBool(m_Attack1Hash, true);
        m_Animator.SetBool(m_IdleHash, false);
        m_Animator.SetBool(m_RunHash, false);
        m_Animator.SetBool(m_JumpHash, false);
        //m_Animator.SetBool(m_GuardHash, false);
    }

    [ContextMenu("Play Idle Anim")]
    public void PlayIdleAnim()
    {
        m_Animator.SetBool(m_Attack1Hash, false);
        m_Animator.SetBool(m_IdleHash, true);
        m_Animator.SetBool(m_RunHash, false);
        m_Animator.SetBool(m_JumpHash, false);
        //m_Animator.SetBool(m_GuardHash, false);
    }

    [ContextMenu("Play Run Anim")]
    public void PlayRunAnim()
    {
        m_Animator.SetBool(m_Attack1Hash, false);
        m_Animator.SetBool(m_IdleHash, false);
        m_Animator.SetBool(m_RunHash, true);
        m_Animator.SetBool(m_JumpHash, false);
        //m_Animator.SetBool(m_GuardHash, false);
    }

    [ContextMenu("Play Jump Anim")]
    public void PlayJumpAnim()
    {
        m_Animator.SetBool(m_Attack1Hash, false);
        m_Animator.SetBool(m_IdleHash, false);
        m_Animator.SetBool(m_RunHash, false);
        m_Animator.SetBool(m_JumpHash, true);
        //m_Animator.SetBool(m_GuardHash, false);
    }

    //[ContextMenu("Play Guard Anim")]
    //public void PlayGuardAnim()
    //{
    //    m_Animator.SetBool(m_Attack1Hash, false);
    //    m_Animator.SetBool(m_IdleHash, false);
    //    m_Animator.SetBool(m_RunHash, false);
    //    m_Animator.SetBool(m_JumpHash, false);
    //    m_Animator.SetBool(m_GuardHash, true);
    //}

    [ContextMenu("Reset Anim")]
    public void ResetAnim()
    {
        m_Animator.SetBool(m_Attack1Hash, false);
        m_Animator.SetBool(m_IdleHash, true);
        m_Animator.SetBool(m_RunHash, false);
        m_Animator.SetBool(m_JumpHash, false);
        //m_Animator.SetBool(m_GuardHash, false);
    }

}
