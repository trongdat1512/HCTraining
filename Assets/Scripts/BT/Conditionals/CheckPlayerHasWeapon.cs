using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class CheckPlayerHasWeapon : EnemyConditionalBase
{
    [SerializeField] private SharedBool isPlayerHasWeapon;

    public override TaskStatus OnUpdate()
    {
        return isPlayerHasWeapon.Value ? TaskStatus.Success : TaskStatus.Failure;
    }
}