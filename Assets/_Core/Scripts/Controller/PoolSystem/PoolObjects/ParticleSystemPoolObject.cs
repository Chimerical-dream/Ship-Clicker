using UnityEngine;
using UnityEngine.UIElements;

namespace Game.Core {

    /// <summary>
    /// pool object for FXs with Particle System
    /// </summary>
	[AddComponentMenu("Common/Pool/Particle System Pool Object")]
    [RequireComponent(typeof(ParticleSystem))]
    public class ParticleSystemPoolObject : PoolObject {
        [SerializeField]
        private ParticleSystem _baseFX;
        public ParticleSystem BaseFX {
            get {
                if (_baseFX == null) {
                    Debug.LogWarning($"[{gameObject.name}] No base FX serialized!");
                    return GetComponent<ParticleSystem>();
                }
                return _baseFX;
            }
        }

        public float Duration => BaseFX.main.duration;
        [Space]
        public bool ReturnToPoolOnPlayed = true;

        public override void OnObjectReuse() {
            base.OnObjectReuse();
            _baseFX.Play();
            if (ReturnToPoolOnPlayed) Destroy(Duration);
        }
    }
}