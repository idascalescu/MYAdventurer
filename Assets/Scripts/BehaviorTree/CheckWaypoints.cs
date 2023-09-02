using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class CheckWaypoints : BTNode//Part of behaviour tree system
{
    private static int _enemyLayerMask = 1 << 6;

    private Transform _transform;

    public CheckWaypoints(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            Collider[] _colliders = Physics.OverlapSphere(
                _transform.position,
                ABehaviorTree.fovRange,
                _enemyLayerMask);

            if (_colliders.Length > 0)
            {
                parent.parent.SetData("target",
                    _colliders[0].transform);
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
