﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumController : TowerController {
    public Sprite Upgraded;
    public int cost = 10;
    public int upgrade = 5;
    public int damage = 2;
    public int level = 1;
    public float cd = 2;
    int onCD = 0;
    float time = 0;
    float timeint = 0;
    
	// Use this for initialization
	void Start () {
        
        PlayerController.money -= cost;
        time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        
        
       
        
        timeint = Time.time - time;
        
        
            if (onCD == 1)
            {
                if (timeint > cd)
                {
                    onCD = 0;
                }
            }
            else
            {
                foreach (GameObject target in targets)
                {
                Debug.Log("Damaging enemy");
                target.GetComponent<EnemyController>().hp -= damage;
                onCD = 1;
                time = Time.time;
                //add effect
                }
            }
	}
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("enemy")){
            targets.Add(other.gameObject);
            Debug.Log("target added");
        }
        
    }
    
    void OnTriggerExit2D( Collider2D other)
    {
        if (other.gameObject.tag.Equals("enemy")){
            targets.Remove(other.gameObject);
            Debug.Log("target removed");
        }
        
    }
    
    
}
