using UnityEngine;
using WB.Base.Core.Components.Wall.WallComponent;
using WB.Base.Core.BaseClass.UpdateBase;
using Zenject;
using System;

public class TriggerComponent : UpdateBase
{
    #region Cons Values
    private const float _attackRange = 1f;
    private const float _deltaTime = 0.016f;
    #endregion

    #region Events
    public event Action AttackSignal;
    #endregion

    #region Private Values
    private int _playerLevel;
    private int _playerPower;
    private float _playerPunchSpeed;
    private float _timer = 0f;
    #endregion

    #region Data Variables
    private PlayerData _playerData;
    private DataManager _dataManager;
    #endregion
    /// <summary>
    /// Get DataManager from DI. We use this manager for getting player data
    /// </summary>
    /// <param name="manager"></param>
    [Inject]
    private void GetManager(DataManager manager)
    {
        _dataManager = manager;
        SetValues();
    }

    private void OnEnable()
    {
        Application.targetFrameRate = 60;
        UpdateEvent += OnUpdate;
        _dataManager.NotifyNewPlayerData += SetValues;
    }

    private void OnDisable()
    {
        UpdateEvent -= OnUpdate;
        _dataManager.NotifyNewPlayerData -= SetValues;
    }

    private void SetValues()
    {
        _playerData = _dataManager.GetPlayerData();
        _playerLevel = _playerData._playerLevel;
        _playerPower = _playerData._playerPower;
        _playerPunchSpeed = _playerData._playerPunchSpeed;
    }

    protected virtual void OnUpdate()
    {
        _timer += _deltaTime;
        if (_timer >= _playerPunchSpeed)
        {
            Raycast();
            _timer = 0;
        }
    }
    private void Raycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, transform.forward, out hit, _attackRange))
        {
            CheckTrigger(hit.collider);
        }
    }

    private void CheckTrigger(Collider other)
    {
        if (other.GetComponent<IWall>() != null)
        {
            WallComponent wallComp = other.GetComponent<WallComponent>();
            if (wallComp.Level <= _playerLevel)
            {
                AttackSignal?.Invoke();
                if (wallComp.TakeDamage(_playerPower))
                {
                    _dataManager.SetExperiance(wallComp.GetWallData().Experiance);
                }
            }
        }
    }
}
