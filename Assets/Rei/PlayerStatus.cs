using System;

/// <summary>
/// プレイヤーのHP、現在の弾の種類や角度を管理する
/// </summary>
public class PlayerStatus
{
    int _maxHP;
    private int _playerHP = 0;
    private int _directionIndex = 0;
    private int _typeIndex = 0;

    /// <summary>弾の種類を変える</summary>
    private MinoDirection _myDirection;
    private MinoDirection[] _directions;
    public MinoDirection Direction => _myDirection;

    /// <summary>弾の角度を変える</summary>
    private MinoType _myType;
    private MinoType[] _types;
    public MinoType Type => _myType;

    public float Rate => 1.0f * _playerHP / _maxHP;

    public PlayerStatus(PlayerDefaultStatus player)
    {
        _maxHP = player.HP;
        _playerHP = player.HP;
        _directions = player.MinoDirections;
        _types = player.MinoTypes;
        _myDirection = _directions[_directionIndex];
        _myType = _types[_typeIndex];
    }

    /// <summary>
    /// ダメージ分HPを減らす
    /// </summary>
    /// <param name="damage"></param>
    public bool DecreaseHP(int damage)
    {
        _playerHP -= damage;
        return _playerHP <= 0;
    }

    /// <summary>
    /// 弾の種類を変えるときに呼ぶ
    /// </summary>
    public void SelectDirection(int move)
    {
        _directionIndex += move;
        if (_directionIndex < 0) _directionIndex = _directions.Length - 1;
        _directionIndex %= _directions.Length;

        _myDirection = _directions[_directionIndex];
    }

    /// <summary>
    /// 弾のタイプを変えるときに呼ぶ
    /// </summary>
    public void SelectType(int move)
    {
        _typeIndex += move;
        if (_typeIndex < 0) _typeIndex = _types.Length - 1;
        _typeIndex %= _types.Length;

        _myType = _types[_typeIndex];
    }
}
