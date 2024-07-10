using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class uiManager : MonoBehaviour
{

    [SerializeField] private TMP_Text m_scoreText;
    [SerializeField] private TMP_Text m_distanceText;
    [SerializeField] private GameObject m_speedMeterScreen;
    [SerializeField] private GameObject m_gameOverPanel;
    [SerializeField] private Slider m_speedMeterSlider;
    [SerializeField] private AnimationCurve m_speedMeterAnimationCurve;
    [SerializeField] private Image m_boostImage;

    private bool m_pause;

    // Start is called before the first frame update
    void Start()
    {
        m_speedMeterScreen.SetActive(true);
    }

    public void ButtonIsPressed()
    {
        m_pause = !m_pause;
        m_speedMeterScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SpeedMeterMoves());
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

    private IEnumerator SpeedMeterMoves()
    {

        float time = 0f;

        while (m_pause is false)
        {
            time += Time.deltaTime;
            m_speedMeterSlider.value = m_speedMeterAnimationCurve.Evaluate(time);
            yield return null;
        }
    }

    public void UpdateBoostUI(float _percentage)
    {
        m_boostImage.fillAmount = _percentage;
    }
}
