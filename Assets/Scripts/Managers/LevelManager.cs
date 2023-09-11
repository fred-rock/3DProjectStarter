using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class LevelManager : MonoBehaviour, IManager
{
    private ObjectPool _objectPooler;

    private void Awake()
    {
        _objectPooler = GetComponent<ObjectPool>();
    }
    public void FlagEvent()
    {
    }
}