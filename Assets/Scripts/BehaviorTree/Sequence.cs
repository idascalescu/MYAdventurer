using System.Collections;
using System.Collections.Generic;

namespace BehaviorTree
{
    public class Sequence : BTNode
    {
        public Sequence() : base() { }
        public Sequence(List<BTNode> children) : base(children) { }
        public override NodeState Evaluate()
        {
            bool anyChildIsRunning = false;

            foreach (BTNode node in children)
            {
                switch (node.Evaluate())//LEAVES
                {
                    case NodeState.FAILURE:
                        state = NodeState.FAILURE;
                        return state;
                    case NodeState.SUCCESS:
                        continue;
                    case NodeState.FLYING:
                        anyChildIsRunning = true;
                        continue;
                    default:
                        state = NodeState.SUCCESS;
                        return state; //For this is what I've done wrong probably
                        /* case NodeState.FAILURE:
                             continue;
                         case NodeState.FLYING:
                             state = NodeState.FLYING;
                             return state;
                         case NodeState.SUCCESS:  
                             state = NodeState.SUCCESS;
                             return state;
                         default:
                             continue;*/
                }
            }

            state = anyChildIsRunning ? NodeState.FLYING : NodeState.SUCCESS;
            return state;
        }
    }
}
