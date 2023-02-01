using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class Flee : EnemyActionBase
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private SharedEnemyData context;
    [SerializeField] private bool isRunning;
    
    public override void OnStart()
    {
        context.Value.animator.SetTrigger(isRunning ? Enemy.RunTrigger : Enemy.WalkTrigger);
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        var fleeDir = -Vector3.Normalize(playerTransform.position - transform.position);
        transform.rotation = Quaternion.LookRotation(fleeDir);
        context.Value.characterController.SimpleMove(fleeDir *
                                                     (isRunning
                                                         ? context.Value.chaseSpeed
                                                         : context.Value.patrolSpeed));
        return TaskStatus.Running;
    }
}