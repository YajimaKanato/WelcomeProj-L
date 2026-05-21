using UnityEngine;

[CreateAssetMenu(fileName = "Units", menuName = "Scriptable Objects/Units")]
public class Units : ScriptableObject
{
    [SerializeField] EnemyUnit[] _units;
    public EnemyUnit[] Unit => _units;
}
