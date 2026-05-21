using UnityEngine;

public class Effect_EnemyDown : MonoBehaviour
{
    public Vector3 playerPos;
    public float radius = 0.1f;
    public GameObject BombEffect;
    int repeatTime = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = gameObject.transform.position;

        if (repeatTime >= 4)
        {
            CancelInvoke(nameof(InstantiateBombEffect));
            repeatTime = 0;

        }

        if (Input.GetMouseButtonDown(0))
        {
            //InstantiateBombEffect();
            

            
        }
    }

    public void Invoke()
    {
        InvokeRepeating(nameof(InstantiateBombEffect), 0.1f, 0.5f);
    }
    

    //public IEnumerator InstantiateBombEffect()
    public void InstantiateBombEffect()
    {
        Vector2 randomPointAroundEnemy = GetRandomPointAroundEnemy(playerPos, radius);

        Instantiate(BombEffect, randomPointAroundEnemy, Quaternion.identity);

        repeatTime++;


        //for (int i = 0; i < 5; i++)
        //{
        //    Instantiate(BombEffect, randomPointAroundEnemy, Quaternion.identity);

        //    yield return new WaitForSeconds(1.0f);
        //}
    }

    public Vector2 GetRandomPointAroundEnemy(Vector2 center, float radius)
    {
        Vector2 randomPoint = center + Random.insideUnitCircle * radius;
        return randomPoint;
    }
}
