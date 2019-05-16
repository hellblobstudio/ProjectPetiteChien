using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public float speed = 100;
   private Vector2 motion = new Vector2();

   private BoxCollider2D boxCollider;

   private bool grounded;
   private void Start()
   {
      this.boxCollider = this.GetComponent<BoxCollider2D>();
   }

   private void FixedUpdate()
   {
      float moveInput = Input.GetAxisRaw("Horizontal");
      motion.x = Mathf.Lerp(0, moveInput * speed, 0.1f);

      if (grounded)
      {
         motion.y = 0;
      }
      else
      {
         motion.y += Physics2D.gravity.y;
      }
      var wantedMotion = new Vector3(motion.x * Time.fixedDeltaTime, motion.y * Time.fixedDeltaTime, 0);
      grounded = false;
      Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position + wantedMotion, boxCollider.size, 0);
      foreach (Collider2D hit in hits)
      {
         if (hit == boxCollider)
            continue;

         ColliderDistance2D colliderDistance = hit.Distance(boxCollider);

         if (colliderDistance.isOverlapped)
         {
            transform.Translate(colliderDistance.pointA - colliderDistance.pointB);

            if (Vector2.Angle(colliderDistance.normal, Vector2.up) == 90 && motion.x != 0)
            {
               Debug.Log(motion);
               wantedMotion.x = 0;
            }
            if (Vector2.Angle(colliderDistance.normal, Vector2.up) < 90 && motion.y < 0)
            {
               grounded = true;
               wantedMotion.y = 0;
            }
         }
      }
      this.transform.Translate(wantedMotion);
   }
}
