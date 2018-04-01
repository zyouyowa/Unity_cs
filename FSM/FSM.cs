using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM <StateEnum, Owner> {
    public Owner owner{ get; private set; }

    public FSMState<StateEnum, Owner> current;

    public Dictionary<StateEnum, FSMState<StateEnum, Owner>> states{ get; private set; }

    public FSM (Owner owner) {
        this.owner = owner;
        current = null;
        states = new Dictionary<StateEnum, FSMState<StateEnum, Owner>> ();
    }

    //Update、またはFixedUpdateなどのタイミングで呼び出す
    public void OnUpdate () {
        if (current.goNextState) {
            var stateType = current.EndState ();
            current = states [stateType];
            current.StartState ();
        } else {
            current.OnUpdate ();
        }
    }

    //ステートの登録を行う
    public void RegistState (FSMState<StateEnum, Owner> state) {
        if (states.Count == 0)
            current = state;
        states.Add (state.stateType, state);
    }
}
