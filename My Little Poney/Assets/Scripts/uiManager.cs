using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour
{

    [SerializeField] private TMP_Text m_scoreText;
    [SerializeField] private TMP_Text m_distanceText;
    [SerializeField] private GameObject m_speedMeterScreen;
    [SerializeField] private GameObject m_gameOverPanel;
    

    // Start is called before the first frame update
    void Start()
    {
        m_speedMeterScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScoreText(int _score)
    {
        m_scoreText.text = _score.ToString() + " points";
    }

    public void UpdateDistance(float _distance)
    {
        m_distanceText.text = _distance.ToString() + " m";
    }

    public void SpeedAndAngleHaveBeenChosen()
    {
        m_speedMeterScreen.SetActive(false);
    }

    public void GameHasEnded()
    {
        m_gameOverPanel.SetActive(true);
    }

    public void RetryGame()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        Debug.Log(currentScene);
        SceneManager.LoadScene(currentScene);
    }
}
