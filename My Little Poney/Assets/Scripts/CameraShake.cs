using Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera m_cinemachineVirtualCamera;
    private float m_shakeTimer;
    // Start is called before the first frame update
    private void Awake()
    {
        m_cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        //enabled = false;
    }

    public void ShakeCamera(float _intensity, float _time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineMulti =
        m_cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineMulti.m_AmplitudeGain = _intensity;

        m_shakeTimer = _time;
    }

    private void Update()
    {
        if (m_shakeTimer > 0)
        {
            m_shakeTimer -= Time.deltaTime;
            if (m_shakeTimer <= 0)
            {
                CinemachineBasicMultiChannelPerlin cinemachineMulti =
                m_cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cinemachineMulti.m_AmplitudeGain = 0f;
            }
        }
    }
}
