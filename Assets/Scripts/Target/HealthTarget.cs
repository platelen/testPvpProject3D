using UnityEngine;

namespace Target
{
    public class HealthTarget : MonoBehaviour
    {
        [SerializeField] private HealthBar.HealthBar _healthBar;
        [SerializeField] private int _maxHealth = 100;
        [SerializeField] private int _currentHealth;

        private void Start()
        {
            _currentHealth = _maxHealth;
            _healthBar.SetMaxHealth(_maxHealth);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TakeDamage(10);
            }
        }

        private void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            _healthBar.SetHealthBar(_currentHealth);
        }
    }
}