using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileWeaponModule : BasePlayerWeaponModule, IPlayerModule
{
    // TODO: Add in firing rate/cooldown timer
    [SerializeField] private float _projectileOriginZOffset = 1f; // How far in front of the player the projectile spawns
    [SerializeField] private ProjectileWeaponData _projectileWeaponData;
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private GameObject _weaponModel; // TODO: Create Weapon class that just wraps the model and animator
    //private Transform _cameraTarget;
    private Vector3 _projectileOrigin;
    private ObjectPool _objectPool;
    private AudioSource _audioSource;
    private Player _player;

    // Optional animation fields
    public const string WEAPON_EQUIP = "equip";
    public const string WEAPON_UNEQUIP = "unequip";
    public const string WEAPON_FIRE = "fire";
    private string _currentAnimationState;
    private Animator _animator;

    public override void Initialize(Player player)
    {
        _player = player;
        _weaponData = _projectileWeaponData; // Will this work?
        //_cameraTarget = _player.FirstPersonLookModule.transform;
        //transform.SetParent(_cameraTarget, true);
        _objectPool = FindObjectOfType<ObjectPool>();
        _audioSource = GetComponentInChildren<AudioSource>();
        _audioSource.playOnAwake = false;
        _animator = GetComponentInChildren<Animator>();
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
            _audioSource.clip = _projectileWeaponData.EquipSFX;
            _audioSource.Play();
        }

        base.Equip();
    }

    public override void Unequip()
    {
        if (_animator != null)
        {
            ChangeAnimationState(WEAPON_UNEQUIP);
        }
        _weaponModel.gameObject.SetActive(false);
        
        base.Unequip();
    }

    public override void Fire()
    {
        UpdateProjectileOrigin();

        if (_audioSource != null)
        {
            _audioSource.clip = _projectileWeaponData.FireSFX;
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

        Projectile projectile;
        if (_objectPool != null && _projectileWeaponData != null)
        {
            float speed = _player.MovementModule.GetCurrentVelocity() + _projectileWeaponData.ProjectileSpeed;

            projectile = _objectPool.GetProjectile(speed, 
                _projectileWeaponData.Damage, 
                _projectileWeaponData.SplashRadius, 
                _projectileWeaponData.DamagesPlayer, 
                _projectileWeaponData.DamagesEnemy, 
                _projectileWeaponData.DamagesEnvironment, 
                _projectileOrigin, 
                _player.transform.rotation);
        }
        else
        {
            projectile = Instantiate(_projectilePrefab, _projectileOrigin, _player.transform.rotation);
        }
        
        base.Fire();
    }

    private void UpdateProjectileOrigin()
    {
        _projectileOrigin = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * .5f, Screen.height * .5f, _projectileOriginZOffset));
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