
using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.XR;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private Enemy context;
    [ShowInInspector] private EnemyStateBase _currentState;

    private void Start()
    {
        _currentState = new EnemyIdleState(context);
    }

    private void Update()
    {
        var newState = _currentState?.OnUpdate();

        if (newState != _currentState)
            ChangeState(newState);
    }

    void ChangeState(EnemyStateBase newState)
    {
        _currentState?.OnExit();
        _currentState = newState;
        _currentState.OnEnter();
    }
}