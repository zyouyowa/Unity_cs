# これはなに

状態遷移をスクリプト上で扱うためのスクリプトです。
FSMというのはFinite State Machine(有限状態機械)の略です。

# 各コードについて

FSM.csとFSMState.csが実装で、それ以外は使用例になります。

|スクリプト|説明|
| --:| :--|
| FSM.cs | 登録された状態を遷移させるものです。状態遷移はFSMクラスのインスタンスから制御します。 |
| FSMState.cs | 状態をつくるための雛形です。具体的な状態を実装する際は、このスクリプトを継承します。 |
| FSMUser.cs | FSMを実際に利用している例です。 |
| WaitState.cs, WalkState.cs |FSMStateを継承して作製した、具体的な状態の実装例です。 |