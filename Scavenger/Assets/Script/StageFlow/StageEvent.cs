using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEvent : StageParent
{
    public override void BeginState()
    {
        base.BeginState();
        if (manager.eventInfo.Count != 0)
            foreach (EventVisualParent events in manager.eventInfo)
            {
                events.Execute();
            }
    }

    private void Update()
    {
        if (manager.eventInfo.Count != 0)
        {
            foreach (EventVisualParent events in manager.eventInfo)
            {
                events.Execute();

            }
            if (manager.callEnd.Count != 0)
            {
                for (; manager.callEnd.Count != 0;)
                {
                    manager.eventInfo.Remove(manager.callEnd.Pop());
                }
            }
        }
        else
            manager.SetState(StageState.IDLE);
    }

    public override void EndState()
    {
        base.EndState();
        //manager.eventInfo.Clear();
    }
}
