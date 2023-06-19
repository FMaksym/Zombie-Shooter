using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseBehaviour : StateMachineBehaviour
{
    NavMeshAgent _agent;
    Transform _player;
    private float _attackRange = 2f;
    private float _chaseRange = 200.0f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent = animator.GetComponent<NavMeshAgent>();
        animator.speed = 2;

        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(_player.position);
        float distance = Vector3.Distance(animator.transform.position, _player.position);

        if (distance < _attackRange)
        {
            animator.SetBool("IsAttack", true);
            animator.transform.LookAt(_player);
        }

        if (distance > _chaseRange) 
        {
            animator.SetBool("IsChase", false);
            animator.SetBool("IsIdle", true); 
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(_agent.transform.position);
        _agent.speed = 2;
    }
}
