using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot2Move : MonoBehaviour
{
    //public input
    public Rigidbody2D player;
    public Camera cam;
    public float moveSpeed = 5f;

    Vector2 movement,mousePos;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
    }
    private void FixedUpdate()
    {
        player.MovePosition(player.position + movement * moveSpeed* Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - player.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        player.rotation = angle;
    }
}
