using UnityEngine;

namespace Bullet
{
    public class DestroyParticle : MonoBehaviour
    {
        private ParticleSystem _particle;

        private void Start()
        {
            _particle = GetComponent<ParticleSystem>();
        }

        private void Update()
        {
            if (_particle.isPlaying == false)
                Destroy(gameObject);
        }
    }
}