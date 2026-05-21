using UnityEngine;

public class EnemyStatus
{
    public EnemyStatus(EnemyStatusBase HpMax)
    {
        _maxHP = HpMax.HpMax;
        _hp = HpMax.HpMax;
    }
    int _maxHP;
    private int _hp;
    public float Rate => 1.0f * _hp / _maxHP;

    public int Damage()
    {
        _hp--;

        if (_hp <= 0)
        {
            _hp = 0;

        }
        if (_hp == 0)
        {

        }
        return _hp;
    }

}
