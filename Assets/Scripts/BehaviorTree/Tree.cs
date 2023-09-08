using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class Tree : MonoBehaviour
    {
        public BTNode root = null;

        protected void Awake()
        {
            root = SetupTree();
        }

        private void Update()
        {
            if (root != null)
            {
                root.Evaluate();
            }
        }

        protected abstract BTNode SetupTree();
    }
}
