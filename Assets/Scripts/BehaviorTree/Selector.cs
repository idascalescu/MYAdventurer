using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class sSelector : BTNode//The selector is sorting the "Leaves"
                                    //the "Leaves" are the actions made by the NPC
    {
        public sSelector() : base() { }
        public sSelector(List<BTNode> children) : base(children) { }

        public override NodeState Evaluate()
        {
            foreach (BTNode node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.FAILURE:
                        continue;
                    case NodeState.SUCCESS:
                        return state;
                    case NodeState.WALKING:
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
