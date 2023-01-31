using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public abstract class EnemyStateBase
{
    protected static readonly int WalkTrigger = Animator.StringToHash("Walk");
    protected static readonly int RunTrigger = Animator.StringToHash("Run");
    protected static readonly int IdleTrigger = Animator.StringToHash("Idle");
    protected static readonly int AttackTrigger = Animator.StringToHash("Attack");
    
    protected Enemy context;

    public EnemyStateBase(Enemy context)
    {
        this.context = context;
    }
    
    public abstract void OnEnter();

    public abstract EnemyStateBase OnUpdate();

    public abstract void OnExit();
    
    protected Vector3 GetRandomPatrolPosition() => new(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));

    protected bool IsPlayerInRange() => Vector3.Distance(context.transform.position, context.player.position) <= context.detectRange;
    protected bool IsPlayerInAttackRange() => Vector3.Distance(context.transform.position, context.player.position) <= context.attackRange;

}