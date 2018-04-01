using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* このステートのクラスは完全にpublicになっていますが、
 * 作りたい状態遷移用の名前空間を作ってその中い入れておくことをお勧めします。
*/
public class WaitState : FSMState<StateTypeExample, FSMUser> {

    public WaitState (FSMUser owner) : base (owner) {
        //基底クラスのコンストラクタへの引数を忘れずに
        //nextStateTypes.Add (StateTypeExample.Walk);
    }

    public override void OnEnter () {
        Debug.Log ("Waiting...");
    }

    public override void OnUpdate () {
        //Wait...
        bool someInput = true;
        if (someInput) {
            GoNextState (StateTypeExample.Walk);
        }
    }
}
