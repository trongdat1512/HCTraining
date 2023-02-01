
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class GetRandomPos : EnemyActionBase
{
    [SerializeField] private SharedVector3 target;
    
    public override void OnStart()
    {
        target.Value = new(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
    }
}