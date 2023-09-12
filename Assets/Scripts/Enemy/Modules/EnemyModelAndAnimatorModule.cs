using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModelAndAnimatorModule : MonoBehaviour, IEnemyModule
{
    [SerializeField] private GameObject _model;
    private Enemy _enemy;

    // Optional animation fields
    public const string ENEMY_FLINCH = "ENEMY_FLINCH";
    public const string ENEMY_ATTACK_RANGED = "ENEMY_ATTACK_RANGED";
    public const string ENEMY_ATTACK_MELEE = "ENEMY_ATTACK_MELEE";
    public const string ENEMY_DEATH = "ENEMY_DEATH";
    private string _currentAnimationState;
    private Animator _animator;

    public void Initialize(Enemy enemy)
    {
        _enemy = enemy;
        _animator = GetComponent<Animator>();
    }

    public void ShowModel()
    {
        _model.SetActive(true);
    }

    public void HideModel()
    {
        _model.SetActive(false);
    }

    public void Flinch()
    {
        if (!IsAnimationPlaying(_animator, ENEMY_FLINCH))
        {
            ChangeAnimationState(ENEMY_FLINCH);

            PlayCurrentAnimation();
        }
    }

    public void RangedAttack()
    {
        if (!IsAnimationPlaying(_animator, ENEMY_ATTACK_RANGED))
        {
            ChangeAnimationState(ENEMY_ATTACK_RANGED);

            PlayCurrentAnimation();
        }
    }

    public void MeleeAttack()
    {
        if (!IsAnimationPlaying(_animator, ENEMY_ATTACK_MELEE))
        {
            ChangeAnimationState(ENEMY_ATTACK_MELEE);

            PlayCurrentAnimation();
        }
    }

    public void Death()
    {
        if (!IsAnimationPlaying(_animator, ENEMY_DEATH))
        {
            ChangeAnimationState(ENEMY_DEATH);

            PlayCurrentAnimation();
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
