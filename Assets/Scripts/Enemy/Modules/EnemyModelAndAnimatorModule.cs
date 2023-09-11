using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModelAndAnimatorModule : MonoBehaviour, IEnemyModule
{
    [SerializeField] private GameObject _model;
    private Enemy _enemy;
    public void Initialize(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void ShowModel()
    {
        _model.SetActive(true);
    }

    public void HideModel()
    {
        _model.SetActive(false);
    }
}
