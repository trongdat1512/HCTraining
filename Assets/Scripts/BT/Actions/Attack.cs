
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class Attack : EnemyActionBase
{
    [SerializeField] private SharedEnemyData context;
    [SerializeField] float attackCooldown;

    private float _attackCooldown;
    public override void OnStart()
    {
        context.Value.animator.SetTrigger(Enemy.AttackTrigger);
        _attackCooldown = attackCooldown;
    }

    public override TaskStatus OnUpdate()
    {
        _attackCooldown -= Time.deltaTime;
        if (_attackCooldown <= 0)
        {
            return TaskStatus.Success;
        }
        
        return TaskStatus.Running;
    }
}