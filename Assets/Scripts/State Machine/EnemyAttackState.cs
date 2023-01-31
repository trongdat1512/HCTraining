using UnityEngine;

public class EnemyAttackState : EnemyStateBase
{
    private float _attackCooldown;
    
    public EnemyAttackState(Enemy context) : base(context)
    {
    }

    public override void OnEnter()
    {
        context.animator.SetTrigger(AttackTrigger);
        _attackCooldown = 2;
    }

    public override EnemyStateBase OnUpdate()
    {
        context.transform.rotation =
            Quaternion.LookRotation(context.player.transform.position - context.transform.position);

        _attackCooldown -= Time.deltaTime;

        if (_attackCooldown <= 0)
        {
            if (IsPlayerInAttackRange())
                return new EnemyAttackState(context);
            else if (IsPlayerInRange())
                return new EnemyChaseState(context);
            else
                return new EnemyPatrolState(context);
        }

        return this;
    }

    public override void OnExit()
    {
        
    }
}