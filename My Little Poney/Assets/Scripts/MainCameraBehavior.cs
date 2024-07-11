
using UnityEngine;

public class MainCameraBehavior : MonoBehaviour
{
    [SerializeField] private ParticleSystem m_perfectLaunch;
    [SerializeField] private CameraShake m_camera;
    [SerializeField] private float m_cameraIntensity = 1;
    [SerializeField] private float m_cameraTime = .2f;

    public void PerfectParticles()
    {
        m_perfectLaunch.Play();
    }
    
    public void CameraShake()
    {
        m_camera.ShakeCamera(m_cameraIntensity, m_cameraTime);
    }
}
