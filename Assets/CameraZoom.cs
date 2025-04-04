using UnityEngine;
using Unity.Cinemachine;

public class CameraZoom : MonoBehaviour
{
    private CinemachineVirtualCamera cam;
    public float zoomOutDistance = -25f; // Distance Z de la caméra

    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
        if (cam != null)
        {
            cam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.z = zoomOutDistance;
        }
        else
        {
            Debug.LogError("Cinemachine Virtual Camera non trouvée sur cet objet !");
        }
    }
}
