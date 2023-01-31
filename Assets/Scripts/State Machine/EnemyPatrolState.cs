

using UnityEngine;

public class EnemyPatrolState : EnemyStateBase
{
    private Vector3 _destinationPoint;
    
    public EnemyPatrolState(Enemy context) : base(context)
    {
    }

    public override void OnEnter()
    {
        context.animator.SetTrigger(WalkTrigger);
        _destinationPoint = GetRandomPatrolPosition();
    }

    public override EnemyStateBase OnUpdate()
    {
        var dir = Vector3.Normalize(_destinationPoint - context.transform.position);
        context.transform.rotation = Quaternion.LookRotation(dir);
        context.characterController.SimpleMove(dir * context.patrolSpeed);


        
        if (Vector3.SqrMagnitude(_destinationPoint - context.transform.position) < .5f)
            return new EnemyIdleState(context);

        if (IsPlayerInRange())
            return new EnemyChaseState(context);

        return this;
    }

    public override void OnExit()
    {
        
    }
}