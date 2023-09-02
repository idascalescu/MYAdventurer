using BehaviorTree;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;

public class ABehaviorTree : Tree
{
    public UnityEngine.Transform [] aWaypoints;

    public static float speed = 2.0f;
    public static float fovRange = 6.0f;

    protected override BTNode SetupTree()
    
    {
        root = new TaskPatrol(transform, aWaypoints);
        return
            root;
    }
}


