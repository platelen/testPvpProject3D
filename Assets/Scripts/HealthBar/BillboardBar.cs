using UnityEngine;

namespace HealthBar
{
    public class BillboardBar : MonoBehaviour
    {
        [SerializeField] private Transform _camera;

        private void Awake()
        {
            _camera = FindObjectOfType<UnityEngine.Camera>().transform;
        }

        private void LateUpdate()
        {
            transform.LookAt(transform.position + _camera.forward);
        }
    }
}