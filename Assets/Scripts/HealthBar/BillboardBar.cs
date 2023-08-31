using System;
using UnityEngine;

namespace HealthBar
{
    public class BillboardBar : MonoBehaviour
    {
        [SerializeField] private Transform _camera;

        private void LateUpdate()
        {
            transform.LookAt(transform.position + _camera.forward);
        }
    }
}