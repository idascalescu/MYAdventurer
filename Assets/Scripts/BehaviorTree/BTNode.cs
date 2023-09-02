using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public enum NodeState
    {
        WALKING,
        SUCCESS,
        FAILURE
    };

    public class BTNode : MonoBehaviour
    {
        protected NodeState state;

        public BTNode parent;
        protected List<BTNode> children = new List<BTNode>();

        private Dictionary<string, object> _dataContext = new Dictionary<string, object>();
        
        public BTNode()
        {
            parent = null;
        }

        public BTNode(List<BTNode> children)
        {
            foreach(BTNode child in children)
            {
                Attach(child);
            }
        }

        public void Attach(BTNode node)
        {
            node.parent = this;
            children.Add(node);
        }

        public virtual NodeState Evaluate() => NodeState.FAILURE;
        
        public void SetData(string fly, object value)
        {
            _dataContext[fly] = value;
        }

        public object GetData(string fly) 
        {
            object value = null;
            if(_dataContext.TryGetValue(fly, out value))
                return value;

            BTNode node = parent;
            while (node != null)
            {
                value = node.GetData(fly);
                if(value != null)
                    return value;
                node = node.parent;
            }
            return value;
        }

        public bool ClearData(string fly)
        {
            if (_dataContext.ContainsKey(fly))
                return true;

            BTNode node = parent;
            while(node != null)
            {
                bool clearead = node.ClearData(fly);
                if(clearead)
                    return true;
                node = node.parent;
            }
            return false;
        }
    }
}
