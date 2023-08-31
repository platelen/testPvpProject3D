using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class GlobalEvents : MonoBehaviour
    {
        public static readonly UnityEvent OnStartAlertNoAmmo = new UnityEvent();
        public static readonly UnityEvent OnStartAmmo = new UnityEvent();

        public static void SendAlertNoAmmo()
        {
            OnStartAlertNoAmmo.Invoke();
        }

        public static void SendStartAmmo()
        {
            OnStartAmmo.Invoke();
        }
    }
}