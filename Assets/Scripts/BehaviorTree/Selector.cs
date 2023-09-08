using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class Selector : BTNode//The selector is sorting the "Leaves"
                                    //the "Leaves" are the actions made by the NPC
    {
        public Selector() : base() { }
        public Selector(List<BTNode> children) : base(children) { }

        public override NodeState Evaluate()
        {
            foreach (BTNode node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.FAILURE:
                        continue;
                    case NodeState.SUCCESS:
                        state = NodeState.SUCCESS;
                        return state;
                    case NodeState.FLYING:
                        state = NodeState.FLYING;
                        return state;
                    default:
                        continue;
                }
            }

            state = NodeState.FAILURE;
            return state;
        }
    }
}
