using BehaviorTree;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using Sequence = BehaviorTree.Sequence;

public class ABehaviorTree : Tree
{
    public UnityEngine.Transform [] aWaypoints;

    public static float speed = 6.0f;
    public static float fovRange = 6.0f;
    public static float attackRange = 1.0f;

    protected override BTNode SetupTree()
    
    {
        /*BTNode root = new BehaviorTree.Sequence(new List<BTNode>
        {
            new CheckEnemyInFOV(transform),
            new GoToTarget(transform),
        });
        new TaskPatrol(transform, aWaypoints);
        return
            root;*/ // Up from git

        BTNode root = new Selector(new List<BTNode>//switching from new Sequence into new Selector cuts of the error
        {
            new Selector (new List<BTNode>
            {
                /*new CheckEnemyInFOV(transform),*/
                /*new GoToTarget(transform),*/
                new TaskPatrol(transform, aWaypoints),
            }),

            /*new Sequence(new List<BTNode>
            {
                new GoToTarget(transform),
            }),*/
        });
        return root;
    }
}


