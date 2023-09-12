using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class GoToTarget : BTNode
{
    private Transform _transform;

    public GoToTarget(Transform transform)
    {
        _transform = transform;
    } 

    public override NodeState Evaluate()
    {
        /*Transform target = (Transform)GetData("target");
        if (Vector3.Distance(_transform.position,
            target.position) > 5.0f)
        {
            _transform.position = Vector3.MoveTowards(
            _transform.position, target.position,
            ABehaviorTree.speed + Time.deltaTime);
            _transform.LookAt(target.position);*/ // After gitUp

        Transform target = (Transform)GetData("target");
        if (Vector3.Distance(_transform.position, target.position) > 0.01f)
        {
            _transform.position = Vector3.MoveTowards(
                _transform.position, target.position, ABehaviorTree.speed * Time.deltaTime);
            _transform.LookAt(target.position);
            Debug.Log("target on VoF");
        }

        state = NodeState.FLYING; return state;
    }
}
