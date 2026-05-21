using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Unit/Unit")]
public class Unit : ScriptableObject
{
    [Header("画像")]
    [SerializeField] private Sprite _unitSprite;
    [Header("自分の設定")]
    [SerializeField] private ConditionSetting _condition;

    public Sprite UnitSprite => _unitSprite;
    public ConditionSetting Conditions => _condition;
}

[Serializable]
public class ConditionSetting
{ 
    [Header("自分の状態")]
    [SerializeField] private MinoDirection _myDirection;
    [Header("自分の形")]
    [SerializeField] private MinoType _myType;

    public MinoDirection MyDirection => _myDirection;
    public MinoType Type => _myType;
}
