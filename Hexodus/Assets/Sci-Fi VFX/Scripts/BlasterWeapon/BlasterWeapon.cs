using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.BlasterWeapon
{
	internal sealed class BlasterWeapon : MonoBehaviour
	{
		public GameObject Bullet;
		public ParticleSystem MuzzleFlashPs;
		public ManualLightBehavior ManualLightBehavior;
		public float BulletSpeed = 1;
		public float LifeTime = 2f;
		public float LifeTimeAfterCollision = 1f;
		public float Duration;
		public bool DestroyOnCollision = true;
        public float shootRate = 1f;
        private float m_shootRateTimeStamp;


        private bool _isEnabled;
		private ParticleSystem[] _muzzleFlashParticleSystems;

		private void Awake()
		{
			MuzzleFlashPs.Stop(withChildren: true);
			_muzzleFlashParticleSystems = MuzzleFlashPs.GetComponentsInChildren<ParticleSystem>();
		}

		private void Update()
		{
            if (Input.GetButton("Fire1"))
            {
                if (Time.time > m_shootRateTimeStamp)
                {
                    Fire();

                    m_shootRateTimeStamp = Time.time + shootRate;
                }
            }
		}

		private void OnEnable()
		{
			_isEnabled = true;
			EnableParticleSystems(_isEnabled);
		}

		private void OnDisable()
		{
			_isEnabled = false;
			EnableParticleSystems(_isEnabled);
		}

		private void Fire()
		{
			if (!_isEnabled)
				return;

			ManualLightBehavior.Play();

			MuzzleFlashPs.Play(withChildren: true);

			InstantiateBullet(Bullet);
		}

		private void InstantiateBullet(GameObject bullet)
		{
			var bulletGo = Instantiate(bullet, transform.position, transform.rotation);
			var blasterBullet = bulletGo.GetComponent<BlasterBullet>();

			blasterBullet.Speed = BulletSpeed;
			blasterBullet.LifeTime = LifeTime;
			blasterBullet.LifeTimeAfterCollision = LifeTimeAfterCollision;
			blasterBullet.DestroyOnCollision = DestroyOnCollision;

			Destroy(bulletGo, LifeTime);
		}

		private void EnableParticleSystems(bool isEnabled)
		{
			foreach (var particleSystems in _muzzleFlashParticleSystems)
			{
				var particleSystemsEmission = particleSystems.emission;
				particleSystemsEmission.enabled = isEnabled;
			}
		}
	}
}
