using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Move_Collision : MonoBehaviour
{
    public Rigidbody2D rigitbody;
    private bool left_move = false;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rigitbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        if (left_move) moveLeft();
        else moveRight();
        checkMove(pos);
    }

    void moveLeft()
    {
        rigitbody.MovePosition(rigitbody.position - new Vector2(0.1f, 0) * moveSpeed * Time.deltaTime);
    }
    void moveRight()
    {
        rigitbody.MovePosition(rigitbody.position + new Vector2(0.1f, 0) * moveSpeed * Time.deltaTime);
    }

    void checkMove(Vector2 pos)
    {
        if (pos.x > 11) left_move = true;
        else if(pos.x < 3) left_move = false;
    }
}
