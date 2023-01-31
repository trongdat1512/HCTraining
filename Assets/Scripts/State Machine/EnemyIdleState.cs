using UnityEngine;

public class EnemyIdleState : EnemyStateBase
{
    private float _idleTime;
    
    public override void OnEnter()
    {
        context.animator.SetTrigger(IdleTrigger);
        _idleTime = 1;
    }

    public override EnemyStateBase OnUpdate()
    {
        _idleTime -= Time.deltaTime;

        if (_idleTime < 0)
            return new EnemyPatrolState(context);

        return this;
    }

    public override void OnExit()
    {
        
    }

    public EnemyIdleState(Enemy context) : base(context)
    {
    }
}