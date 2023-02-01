using UnityEngine;
using BehaviorDesigner.Runtime;

[System.Serializable]
public class SharedEnemyData : SharedVariable<Enemy>
{
	public override string ToString() { return mValue == null ? "null" : mValue.ToString(); }
	public static implicit operator SharedEnemyData(Enemy value) { return new SharedEnemyData { mValue = value }; }
}