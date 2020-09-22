using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAndMove : MonoBehaviour
{
    //public input
    public Rigidbody2D player;
    public Camera cam;
    public float moveSpeed = 5f;
    public Transform firePoint;
    public Transform movePoint;
    public GameObject BulletPrefab;
    public float bulletForce = 20f;

    Vector2 movement, mousePos;

    // Update is called once per frame
    void Update()
    {
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            player.AddForce(movePoint.up * moveSpeed, ForceMode2D.Impulse);
        }

    }
    private void FixedUpdate()
    {
        //player.MovePosition(player.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - player.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        player.rotation = angle;
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        //Debug.Log("fire");
    }
}
