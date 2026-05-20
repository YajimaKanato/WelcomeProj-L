using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDefaultStatus", menuName = "Scriptable Objects/PlayerDefaultStatus")]
public class PlayerDefaultStatus : ScriptableObject
{
    [SerializeField] int _hp = 10;
    [SerializeField] MinoType[] _minoTypes;
    [SerializeField] MinoDirection[] _minoDirections;

    public int HP => _hp;
    public MinoType[] MinoTypes => _minoTypes;
    public MinoDirection[] MinoDirections => _minoDirections;
}
