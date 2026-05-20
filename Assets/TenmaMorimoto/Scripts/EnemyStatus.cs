using UnityEngine;

public class EnemyStatus
{
    public EnemyStatus(EnemyStatusBase HpMax)
    {
        _hp = HpMax.HpMax;
    }
        
     private int _hp;
 
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
