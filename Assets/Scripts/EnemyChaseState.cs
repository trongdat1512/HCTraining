using UnityEngine;

public class EnemyChaseState : EnemyStateBase
{
    public EnemyChaseState(Enemy context) : base(context)
    {
    }

    public override void OnEnter()
    {
        context.animator.SetTrigger(RunTrigger);
    }

    public override EnemyStateBase OnUpdate()
    {
        var dir = Vector3.Normalize(context.player.position - context.transform.position);
        context.transform.rotation = Quaternion.LookRotation(dir);
        context.characterController.SimpleMove(dir * context.chaseSpeed);

        if (!IsPlayerInRange())
            return new EnemyPatrolState(context);

        if (IsPlayerInAttackRange())
            return new EnemyAttackState(context);

        return this;
    }

    public override void OnExit()
    {
        
    }
}