
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class Idle : EnemyActionBase
{
    [SerializeField] private SharedEnemyData context;
    [SerializeField] private float idleTime;

    private float _idleTime;

    public override void OnStart()
    {
        context.Value.animator.SetTrigger(Enemy.IdleTrigger);
        _idleTime = idleTime;
    }

    public override TaskStatus OnUpdate()
    {
        _idleTime -= Time.deltaTime;

        if (_idleTime <= 0)
            return TaskStatus.Success;
        return TaskStatus.Running;
    }
}