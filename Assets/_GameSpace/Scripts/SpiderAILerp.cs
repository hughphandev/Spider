using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Lean.Pool;

public class SpiderAILerp : AILerp
{
    public override void OnTargetReached()
    {
        base.OnTargetReached();
        LeanPool.Despawn(gameObject);
    }
}
