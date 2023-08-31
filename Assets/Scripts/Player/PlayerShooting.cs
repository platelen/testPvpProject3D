using Events;
using Target;
using TMPro;
using UnityEngine;

namespace Player
{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textCurrentBullet;
        [SerializeField] private TextMeshProUGUI _textAllMagazinesBullet;
        [SerializeField] private int _allMagazines = 3; //TODO можно перенести в отдельный управляющий класс.
        [SerializeField] private int _bulletInMagazine = 10;
        [SerializeField] private float _fireRate = 7f;
        [SerializeField] private int _damage = 10;
        [SerializeField] private float _range;
        [SerializeField] private ParticleSystem _particleShoot;
        [SerializeField] private ParticleSystem _particleEffectAfterShoot;

        private int _bulletsCurrent;
        private bool _isNoAmmo;
        private float _nextFire = 0f;

        private void Start()
        {
            _isNoAmmo = false;
            _bulletsCurrent = _bulletInMagazine;
        }

        private void Update()
        {
            if (Input.GetButton("Fire1") && _bulletsCurrent > 0 && Time.time > _nextFire)
            {
                _nextFire = Time.time + 1f / _fireRate;
                Shoot();
            }

            if (_bulletsCurrent == 0 && Input.GetKeyDown(KeyCode.R) && _isNoAmmo == false)
            {
                _bulletsCurrent = _bulletInMagazine;
                _allMagazines--;
            }

            if (_allMagazines <= 0)
            {
                _isNoAmmo = true;
                GlobalEvents.SendAlertNoAmmo();
            }
            else
            {
                _isNoAmmo = false;
                GlobalEvents.SendStartAmmo();
            }

            _textCurrentBullet.text = _bulletsCurrent + " /";
            _textAllMagazinesBullet.text = _allMagazines.ToString();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(UnityEngine.Camera.main.transform.position,
                UnityEngine.Camera.main.transform.forward * _range);
        }

        public void Shoot()
        {
            _bulletsCurrent--;
            _particleShoot.Play();

            RaycastHit hit;
            if (Physics.Raycast(UnityEngine.Camera.main.transform.position,
                    UnityEngine.Camera.main.transform.forward, out hit, _range))
            {
                Debug.Log(hit.collider.name);
                Instantiate(_particleEffectAfterShoot, hit.point, Quaternion.identity);
                if (hit.collider.CompareTag($"Enemy"))
                {
                    hit.collider.gameObject.GetComponent<HealthTarget>().TakeDamage(_damage);
                }
            }
        }
    }
}