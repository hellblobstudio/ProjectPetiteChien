using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public float speed = 100f;
   private Vector2 motion = new Vector2();

   private Rigidbody2D rb;

   private void Start()
   {
      this.rb = this.GetComponent<Rigidbody2D>();
   }
   private void Update()
   {
      motion.x = Input.GetAxis("Horizontal") * speed;
      Debug.Log(motion.x);
   }

   private void FixedUpdate()
   {
      this.rb.AddForce(motion);
   }
}
