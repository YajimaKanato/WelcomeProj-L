using UnityEngine;

[CreateAssetMenu(fileName = "UnitList", menuName = "Unit/UnitList")]
public class UnitList : ScriptableObject
{
    [Header("UnitList")]
    [SerializeField] private Unit[] _unitList;

    public Unit[] UnitsList => _unitList;
}
