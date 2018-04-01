using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* この列挙型は完全にpublicになっていますが、
 * 作りたい状態遷移用の名前空間を作ってその中い入れておくことをお勧めします。
*/
public enum StateTypeExample {
    Wait,
    Walk
}

//状態遷移を扱ってみる例です
public class FSMUser : MonoBehaviour {

    FSM<StateTypeExample, FSMUser> fsm;

    void Start () {
        fsm = new FSM<StateTypeExample, FSMUser> (this);
        fsm.RegistState (new WaitState (this));
        fsm.RegistState (new WalkState (this));
    }

    void Update () {
        //これをOnFixedUpdate()で呼べば固定周期で実行可能になる。
        //fsm.onFixedUpdateを実装してしまうのもok
        fsm.OnUpdate ();
    }
}
