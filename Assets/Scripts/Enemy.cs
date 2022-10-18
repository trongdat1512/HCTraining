using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public CharacterController characterController;
    public Transform player;
    public float detectRange;
    public float attackRange;
    public float patrolSpeed;
    public float chaseSpeed;
    private EnemyState _state;
    private Vector3 _destinationPoint;
    private float _idleTime = 1;
    
    private static readonly int WalkTrigger = Animator.StringToHash("Walk");
    private static readonly int RunTrigger = Animator.StringToHash("Run");
    private static readonly int IdleTrigger = Animator.StringToHash("Idle");
    private static readonly int AttackTrigger = Animator.StringToHash("Attack");

    // Update is called once per frame
    /*void Update()
    {
        if (IsPlayerInRange())
            Chase();
        else
        {
            if (_idleTime > 0)
            {
                Idle();
                _idleTime -= Time.deltaTime;
            }
            else
            {
                Patrol();
                
                if (Vector3.SqrMagnitude(_destinationPoint - transform.position) < .5f)
                    Idle();
            }
        }
    }*/

    void Idle()
    {
        if (_state != EnemyState.Idle)
        {
            _state = EnemyState.Idle;
            animator.SetTrigger(IdleTrigger);
            _idleTime = 1;
        }
    }
    
    void Patrol()
    {
        if (_state != EnemyState.Patrol)
        {
            _state = EnemyState.Patrol;
            animator.SetTrigger(WalkTrigger);
            _destinationPoint = GetRandomPatrolPosition();
        }

        var dir = Vector3.Normalize(_destinationPoint - transform.position);
        transform.rotation = Quaternion.LookRotation(dir);
        characterController.SimpleMove(dir * patrolSpeed);
    }

    void Chase()
    {
        if (_state != EnemyState.Chase)
        {
            _state = EnemyState.Chase;
            animator.SetTrigger(RunTrigger);
        }
        
        var dir = Vector3.Normalize(player.position - transform.position);
        transform.rotation = Quaternion.LookRotation(dir);
        characterController.SimpleMove(dir * chaseSpeed);
    }
    
    Vector3 GetRandomPatrolPosition() => new(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));

    bool IsPlayerInRange() => Vector3.Distance(transform.position, player.position) <= detectRange;

    #region Gizmo

    private void OnDrawGizmosSelected()
    {
        DrawWireDisk(transform.position, detectRange, Color.yellow);
        
        if (_state == EnemyState.Patrol)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, _destinationPoint);
        }
        else if (_state == EnemyState.Chase)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, player.position);
        }
        
        DrawWireDisk(transform.position, attackRange, Color.red);
    }

    void DrawWireDisk(Vector3 position, float radius, Color color)
    {
        Gizmos.color = color;
        Matrix4x4 oldMatrix = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(position, Quaternion.identity, new Vector3(1, .001f, 1));
        Gizmos.DrawWireSphere(Vector3.zero, radius);
        Gizmos.matrix = oldMatrix;
    }

    #endregion
}

public enum EnemyState
{
    Idle,
    Patrol,
    Chase
}
