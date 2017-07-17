using UnityEngine;

public class GlowController : MonoBehaviour
{
    private RaycastHit _hittingObject;
    private Color _startColor;
    private GameObject _currentGlowingObject;

    private void Update()
    {
        var isHittingObject = Physics.Linecast(Camera.main.transform.position,
            Camera.main.transform.position + Camera.main.transform.forward * 3,
            out _hittingObject);

        if (!GameStates.IsGrabbing && _currentGlowingObject == null && isHittingObject &&
            _hittingObject.transform.gameObject.CompareTag(Constants.GrabbableTag))
        {
            _currentGlowingObject = _hittingObject.collider.gameObject;
            _startColor = _currentGlowingObject.GetComponent<Renderer>().material.color;
            _currentGlowingObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            if (_currentGlowingObject == null || !GameStates.IsGrabbing && _hittingObject.collider != null &&
                _hittingObject.collider.gameObject == _currentGlowingObject)
            {
                return;
            }
            _currentGlowingObject.GetComponent<Renderer>().material.color = _startColor;
            _currentGlowingObject = null;
        }
    }
}