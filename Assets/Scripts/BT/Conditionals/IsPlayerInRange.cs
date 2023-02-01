
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class IsPlayerInRange : EnemyConditionalBase
{
    [SerializeField] private Transform player;
    [SerializeField] private float detectRange;

    public override TaskStatus OnUpdate()
    {
        bool isInRange = Vector3.Distance(transform.position, player.position) <= detectRange;
        
        return isInRange ? TaskStatus.Success : TaskStatus.Failure;
    }
}