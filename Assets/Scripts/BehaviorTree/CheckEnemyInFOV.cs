using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CheckEnemyInFOV : BTNode
{
    private static int _enemyLayerMask = 1 << 6;
    private Transform _transform;

    public CheckEnemyInFOV(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        object obj = GetData("target");
        if (obj != null)
        {
            Collider[] colliders = Physics.OverlapSphere(
            _transform.position, ABehaviorTree.fovRange, _enemyLayerMask);
            if (colliders.Length > 0)
            {
                parent.parent.SetData("target", colliders[0].transform);
                state = NodeState.SUCCESS;
                return state;
            }

            state = NodeState.FAILURE;
            return state;
        }
        state = NodeState.SUCCESS;
        return state;
    }
}
