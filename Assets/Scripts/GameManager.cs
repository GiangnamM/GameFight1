using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_pausePanel;

    [SerializeField]
    public GameObject m_GameplayPanel;

    [SerializeField]
    private Button m_resumeBtn;

    PlayerP2Movement m_Player2P;
    PlayerMovement m_Player1P;


    private void Start()
    {
        m_Player1P = GetComponent<PlayerMovement>();
        m_Player2P = GetComponent<PlayerP2Movement>();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        m_pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        m_pausePanel.SetActive(false);
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
 
}
