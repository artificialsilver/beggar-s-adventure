using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    [SerializeField] int nextMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rigid = GetComponent<Rigidbody2D>();
        Think();


    }

    // Update is called once per frame
    void Update()
    {
        //Move
        rigid.linearVelocity = new Vector2(nextMove, rigid.linearVelocity.y);

        //Platform Check
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down * 1.2f, Color.green);
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1.2f, LayerMask.GetMask("Platform"));
        Debug.Log(rayHit.collider);
        
        //Turn
        if (rayHit.collider == null) // == , !=
        {   
            CancelInvoke();
            nextMove *= -1;
            Think();
                
        }
    }


    void Think()
    {
        nextMove = Random.Range(-1, 2);

        Invoke("Think", 2);
    }
}
