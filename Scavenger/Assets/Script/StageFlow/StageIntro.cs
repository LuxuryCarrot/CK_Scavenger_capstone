using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageIntro : StageParent
{
    public override void BeginState()
    {
        base.BeginState();
    }

    private void Update()
    {
        if(manager.introInfo!=null)
          manager.introInfo.Execute();
    }

    public override void EndState()
    {
        base.EndState();
    }
}
