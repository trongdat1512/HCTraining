
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class GoTo : EnemyActionBase
{
    [SerializeField] private SharedEnemyData context;
    [SerializeField] private SharedVector3 destination;
    [SerializeField] private bool isRunning;
    
    public override void OnStart()
    {
        context.Value.animator.SetTrigger(isRunning ? Enemy.RunTrigger : Enemy.WalkTrigger);
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        var dir = Vector3.Normalize(destination.Value - transform.position);
        transform.rotation = Quaternion.LookRotation(dir);
        context.Value.characterController.SimpleMove(dir *
                                                     (isRunning
                                                         ? context.Value.chaseSpeed
                                                         : context.Value.patrolSpeed));

        if (Vector3.SqrMagnitude(destination.Value - transform.position) < .5f)
            return TaskStatus.Success;
            
        return TaskStatus.Running;
    }

    public override void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(destination.Value, Vector3.one * .1f);
    }
}