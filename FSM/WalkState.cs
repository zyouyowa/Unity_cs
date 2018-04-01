using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : FSMState<StateTypeExample, FSMUser> {

    public WalkState (FSMUser owner) : base (owner) {
        //nextStateTypes.Add (StateTypeExample.Wait);
    }

    public override void OnEnter () {
        Debug.Log ("Start Move");
    }

    public override void OnUpdate () {
        Move ();
        bool noInput = true;
        if (noInput) {
            GoNextState (StateTypeExample.Wait);
        }
    }

    public override void OnExit () {
        Debug.Log ("Stop Move");
    }

    public void Move () {
        //Move
    }
}
