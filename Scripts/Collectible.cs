using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class Collectible : MonoBehaviour {
     public Timer timerScript;
     public CarController playerScript;
     public CollectManage cm;
     public GameObject ct;
     public float speedIncrease;
     public float speedDecrease;
     public enum TypeOfCollectible {SpeedIncrease, TimePowerup, SpeedReduce, Default}
     public TypeOfCollectible type;

     private AudioSource source;

     // Start is called before the first frame update

     void Start()
     {
        source = GetComponent<AudioSource>();
     }

     void Awake() {
        GameObject timer = GameObject.FindGameObjectWithTag("Timer");
        timerScript = timer.GetComponent<Timer>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<CarController>();
        ct = GameObject.FindGameObjectWithTag("CT");
        cm = ct.GetComponent<CollectManage>();
     }
     private void OnTriggerEnter(Collider other)
     {
         if(other.gameObject.tag == "Player") {
            source.Play();            
            switch(type) {
               case TypeOfCollectible.Default:
                   RemovePowerup();
                   break;
               case TypeOfCollectible.TimePowerup:
                   AddTime(100f);
                   break;
               case TypeOfCollectible.SpeedReduce:
                   StartCoroutine(SpeedDown(10f, RemovePowerup));
                   break;
               default:
                   StartCoroutine(SpeedUp(5f, RemovePowerup));
                   break;
            }
            //Destroy(other.gameObject);
         }
     }

   private void AddTime(float timeToAdd) {
       timerScript.timeLeft += timeToAdd;

       RemovePowerup();
   }

   IEnumerator SpeedUp(float waitTime, Action action) {
      print(playerScript.CurrentSpeed);
      playerScript.MaxSpeed += speedIncrease;
      yield return new WaitForSeconds(waitTime);
      print(playerScript.CurrentSpeed);
      playerScript.MaxSpeed -= speedIncrease;

      action();
   }

   IEnumerator SpeedDown(float waitTime, Action action) {
      print(playerScript.CurrentSpeed);
      playerScript.MaxSpeed -= speedDecrease;
      yield return new WaitForSeconds(waitTime);
      print(playerScript.CurrentSpeed);
      playerScript.MaxSpeed += speedDecrease;

      action();
   }

   void RemovePowerup() {
      Debug.Log("Coroutine has ended");
      cm.collectedSoFar += 1;
      Destroy(gameObject);
   }
}
