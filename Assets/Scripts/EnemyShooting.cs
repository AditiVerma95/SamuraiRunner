using System;
using System.Timers;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {
   public GameObject bullet;
   private GameObject player;
   public Transform bulletTransform;
   private float timer;
   
   private void Start() {
      player = GameObject.FindWithTag("Player");
   }

   private void Update() {
      if (player == null) {
         return;
      }
      float distance = Vector2.Distance(transform.position, player.transform.position);
       
      if(distance < 5f){
         timer += Time.deltaTime;
         if (timer > 2) {
            timer = 0;
            Shoot();
         }
      }
      
   }

   public void Shoot() {
      Instantiate(bullet, bulletTransform.position, Quaternion.identity);
   }
}
