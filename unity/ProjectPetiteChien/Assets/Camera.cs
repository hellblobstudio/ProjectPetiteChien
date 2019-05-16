using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
   public GameObject player;

   private void Awake()
   {
      Application.targetFrameRate = 60;
   }

   private void FixedUpdate()
   {
      this.transform.position = new Vector3(Mathf.Lerp(this.transform.position.x, player.transform.position.x, 0.1f), Mathf.Lerp(this.transform.position.y, player.transform.position.y, 0.1f), -10f);
   }
}
