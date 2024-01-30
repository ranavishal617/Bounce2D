using UnityEngine;
using UnityEngine.Tilemaps;

public class Enemy : MonoBehaviour
{
    public TileData tr;
    public Move MoveThisEnemy = new Move();

    public bool move;
    public float EnemyMoveSpeed;

    public Vector3 Current;
    // current Transform Value
    private void Start()
    {
        Current = transform.position;
    }

    // GameObject Moveing Work Code
    void Update()
    {

        if(MoveThisEnemy == Move.Enemy_Up_Down)
        {
            if (move)
            {
                transform.Translate(0f, EnemyMoveSpeed * Time.deltaTime, 0);
            }
            else
            {
                transform.Translate(0f, -EnemyMoveSpeed * Time.deltaTime, 0);
            }
        }

        // -------------------

        if (MoveThisEnemy == Move.Enemy_Right_Left)
        {
            if (move)
            {
                transform.Translate(EnemyMoveSpeed * Time.deltaTime, 0 , 0);
            }
            else
            {
                transform.Translate(-EnemyMoveSpeed * Time.deltaTime, 0, 0);
            }
        }


    }

    // + - Only Need Up And Down value Destance 1 Value Demo >> +y = 45 && -y = 44 
    void OnCollisionEnter2D(Collision2D co)
    {
        if (co.collider.CompareTag("Ground")|| co.collider.CompareTag("ExGround") || co.collider.CompareTag("Jump"))
        {
            if(MoveThisEnemy == Move.Enemy_Up_Down)
            {
                if (this.transform.position.y > Current.y + 0.01f)
                {
                    move = false;
                }
                if (this.transform.position.y < Current.y - 0.01)
                {
                    move = true;
                }
            }

            //------------------

            if (MoveThisEnemy == Move.Enemy_Right_Left)
            {
                if (this.transform.position.x > Current.x + 0.01f)
                {
                    move = false;
                }
                if (this.transform.position.x < Current.x - 0.01)
                {
                    move = true;
                }
            }

        }
    }
}


