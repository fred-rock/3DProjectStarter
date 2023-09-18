using UnityEngine;

public class PlayerHitscanWeaponModule : BasePlayerWeaponModule, IPlayerModule
{
    // TODO: Add in firing rate/cooldown timer
    [SerializeField] private HitscanWeaponData _hitscanWeaponData;
    [SerializeField] private GameObject _weaponModel;
    private LayerMask _hitboxLayer;
    private Player _player;
    private EnemyHitboxModule _enemyHitbox;
    private AudioSource _audioSource;
    private ParticleSystem _muzzleFlashParticles;

    // Optional animation fields
    public const string WEAPON_EQUIP = "equip";
    public const string WEAPON_UNEQUIP = "unequip";
    public const string WEAPON_FIRE = "fire";
    private string _currentAnimationState;
    private Animator _animator;

    //  Firing timer
    private float _fireRate;
    private float _timer;
    private bool _canFire;

    // Optional player module
    private PlayerAmmoModule _ammoModule;

    public override void Initialize(Player player)
    {
        _player = player;
        _weaponData = _hitscanWeaponData;
        _fireRate = _weaponData.FireRate;
        _canFire = true;

        _audioSource = GetComponentInChildren<AudioSource>();
        _audioSource.playOnAwake = false;
        _muzzleFlashParticles = GetComponentInChildren<ParticleSystem>();
        _hitboxLayer = LayerMask.GetMask("Hitbox");
        _animator = GetComponentInChildren<Animator>();
        _ammoModule = _player.AmmoModule;
    }

    private void Update()
    {
        _timer += Time.deltaTime; // TODO: Move to base class
        if (_timer > _fireRate)
        {
            _canFire = true;
            _timer = 0;
        }
    }

    public override void Equip()
    {
        _weaponModel.gameObject.SetActive(true);

        if (_animator != null)
        {
            ChangeAnimationState(WEAPON_EQUIP);
        }

        if (_audioSource != null)
        {
            _audioSource.clip = _hitscanWeaponData.EquipSFX;
            _audioSource.Play();
        }

        base.Equip();
    }

    public override void Unequip()
    {
        _weaponModel.gameObject.SetActive(false);

        if (_animator != null)
        {
            ChangeAnimationState(WEAPON_UNEQUIP);
        }

        base.Unequip();
    }

    private bool HasAmmo()
    {
        if (_ammoModule != null)
        {
            if (_ammoModule.GetCurrentAmount(_weaponData.AmmoType) >= _weaponData.AmmoConsumedPerSingleUse)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            Debug.Log("No ammo module");
            return true;
        }
    }

    public override void AttemptFire()
    {
        if (_canFire && HasAmmo())
        {
            Fire();
            _canFire = false;

            if (_ammoModule != null)
            {
                _ammoModule.Decrease(_weaponData.AmmoType, _weaponData.AmmoConsumedPerSingleUse);
            }
        }
        base.AttemptFire();
    }

    public override void Fire()
    {
        FireRaycast();

        if (_muzzleFlashParticles != null && !_muzzleFlashParticles.isPlaying)
        {
            _muzzleFlashParticles.Play();
        }

        if (_audioSource != null)
        {
            _audioSource.clip = _hitscanWeaponData.FireSFX;
            _audioSource.Play();
        }

        if (_animator != null)
        {
            if (_currentAnimationState != WEAPON_FIRE)
            {
                ChangeAnimationState(WEAPON_FIRE);
            }

            PlayCurrentAnimation();
        }

        if (_enemyHitbox != null)
        {
            _enemyHitbox.AttemptDamage(_hitscanWeaponData.Damage);
        }

        base.Fire();
    }

    private void FireRaycast()
    {
        Vector3 raycastOrigin = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * .5f, Screen.height * .5f, 0f));
        Vector3 raycastDirection = Camera.main.transform.forward;
        RaycastHit hit;

        if (Physics.Raycast(raycastOrigin, raycastDirection, out hit, _hitscanWeaponData.Range, _hitboxLayer))
        {
            _enemyHitbox = hit.transform.gameObject.GetComponent<EnemyHitboxModule>();
        }
    }

    private void ChangeAnimationState(string animationState)
    {
        if (_currentAnimationState == animationState)
        {
            return;
        }

        _currentAnimationState = animationState;
    }

    private void PlayCurrentAnimation()
    {
        if (_currentAnimationState != null)
        {
            _animator.Play(_currentAnimationState, -1, 0f);
        }
    }

    private bool IsAnimationPlaying(Animator animator, string animationState)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(animationState) &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f) // Checks if animation is done playing. A normalizedTime of 1 means the animation is done.
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}