using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] HumanoidLandInput _input;
    [SerializeField] float _cameraZoomModifier = 0.2f;

    private float minCameraZoomDistance = 0f;
    private float maxCameraZoomDistance = 2.5f;

    public CinemachineVirtualCamera cinemachineVirtualCamera;
    CinemachineFramingTransposer _cinemachineFramingTransposer;

    public Camera cam;

    private void Start()
    {
        _cinemachineFramingTransposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
    }
    private void Update()
    {
        if (!(_input.ZoomCameraInput == 0f))
        {
            ZoomCamera();
        }
    }
    private void ZoomCamera() 
    {
        _cinemachineFramingTransposer.m_CameraDistance = Mathf.Clamp(_cinemachineFramingTransposer.m_CameraDistance + 
                            (!_input.InvertScroll ? _input.ZoomCameraInput : -_input.ZoomCameraInput) / _cameraZoomModifier,
                            minCameraZoomDistance,
                            maxCameraZoomDistance);
    }
}
