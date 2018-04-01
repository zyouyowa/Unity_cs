using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMState <StateEnum, Owner> {
    public Owner owner{ get; private set; }

    public StateEnum stateType{ get; protected set; }

    //つながりを持つノードの情報が欲しい場合に使う
    //public List<StateEnum> nextStateTypes{ get; protected set; }

    public StateEnum nextStateType{ get; private set; }

    public bool goNextState{ get; private set; }


    public FSMState (Owner owner) {
        this.owner = owner;
        //nextStateTypes = new List<StateEnum> ();
    }

    public void StartState () {
        goNextState = false;
        OnEnter ();
    }

    public StateEnum EndState () {
        OnExit ();
        return nextStateType;
    }

    //ステートに入ったときに一度だけ呼ばれる
    public virtual void OnEnter () {
    }
    //ステートに入っている間Updateのタイミングで呼ばれる
    public virtual void OnUpdate () {
    }
    //ステートを出るときに一度だけ呼ばれる
    public virtual void OnExit () {
    }

    //次のステートに移行する
    public void GoNextState (StateEnum stateType) {
        //if (nextStateTypes.Contains (stateType)) {
        nextStateType = stateType;
        goNextState = true;
        //}
    }
}
