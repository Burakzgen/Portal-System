using UnityEngine;

public class PortalGunController : MonoBehaviour
{
    public GameObject bluePortal, redPortal;
    private Camera _cam;
    private RaycastHit _hit;

    private void Start()
    {
        _cam = Camera.main;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (SendRay())
            {
                OpenBluePortal();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (SendRay())
            {
                OpenRedPortal();
            }
        }
    }
    private void OpenBluePortal()
    {
        bluePortal.transform.position = _hit.point;
        bluePortal.transform.forward = _hit.transform.forward;
        bluePortal.SetActive(true);
    }
    private void OpenRedPortal()
    {
        redPortal.transform.position = _hit.point;
        redPortal.transform.forward = _hit.transform.forward;
        redPortal.SetActive(true);
    }
    public bool SendRay()
    {
        if (Physics.Raycast(_cam.gameObject.transform.position, _cam.gameObject.transform.forward, out _hit, 100))
        {
            if (_hit.collider.CompareTag("Wall"))
            {
                return true;

            }
        }
        return false;
    }
}
