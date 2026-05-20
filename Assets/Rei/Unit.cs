using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Unit/Unit")]
public class Unit : ScriptableObject
{
   
    [Header("自分の設定")]
    [SerializeField] private ConditionSetting _condition;
    [Header("対応するミノの設定")]
    [SerializeField] private CorrespondSetting _unitSetting;
  
    public ConditionSetting Conditions => _condition;
    public CorrespondSetting UnitSetting => _unitSetting;
}

[Serializable]
public class ConditionSetting
{
    [Header("画像")]
    [SerializeField] private Sprite _unitSprite;
    [Header("自分の状態")]
    [SerializeField] private MinoDirection _myDirection;
    [Header("自分の形")]
    [SerializeField] private MinoType _myType;

    public Sprite UnitSprite => _unitSprite;
    public MinoDirection MyDirection => _myDirection;
    public MinoType Type => _myType;
}

[Serializable]
public class CorrespondSetting
{
    [Header("対応する状態")]
    [SerializeField] private MinoDirection _correspondDirection;
    [Header("対応する形")]
    [SerializeField] private MinoType _correspondType;

    public MinoDirection CorrespondDirection => _correspondDirection;

    public MinoType Type => _correspondType;
}
