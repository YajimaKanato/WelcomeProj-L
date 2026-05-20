using System;

/// <summary>
/// プレイヤーのHP、現在の弾の種類や角度を管理する
/// </summary>
public class PlayerStatus
{
    private int _playerHP = 0;
    private int _directionIndex = 0;
    private int _typeIndex = 0;

    /// <summary>弾の種類を変える</summary>
    private MinoDirection _myDirection;
    private MinoDirection[] _directions = (MinoDirection[])Enum.GetValues(typeof(MinoDirection));

    /// <summary>弾の角度を変える</summary>
    private MinoType _myType;
    private MinoType[] _types = (MinoType[])Enum.GetValues(typeof(MinoType));

    public PlayerStatus(int hp)
    {
        _playerHP = hp;
        _myDirection = _directions[_directionIndex];
        _myType = _types[_typeIndex];
    }

    /// <summary>
    /// ダメージ分HPを減らす
    /// </summary>
    /// <param name="damage"></param>
    public void DecreaseHP(int damage)
    {
        _playerHP -= damage;
        if (_playerHP < 0)
        {

        }//HP0以下で通知発行
    }

    /// <summary>
    /// 弾の種類を変えるときに呼ぶ
    /// </summary>
    public void SelectDirection()
    {
        if (_directionIndex < _directions.Length - 1)
            _directionIndex++;
        else
            _directionIndex = 0;

        _myDirection = _directions[_directionIndex];
    }

    /// <summary>
    /// 弾のタイプを変えるときに呼ぶ
    /// </summary>
    public void SelectType()
    {
        if (_typeIndex < _types.Length - 1)
            _typeIndex++;
        else
            _typeIndex = 0;

        _myType = _types[_typeIndex];
    }
}
