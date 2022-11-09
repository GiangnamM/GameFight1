using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockBackFeedBack : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_rb;

    [SerializeField]
    private float strengh = 16, delay = 0.15f;

    public UnityEvent OnBegin, OnDone;

    public void PlayFeedBack(GameObject sender)
    {
        StopAllCoroutines();
        OnBegin?.Invoke();
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        m_rb.AddForce(strengh * direction, ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(delay);
        m_rb.velocity = Vector3.zero;
        OnDone?.Invoke();
    }


   
}
