using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public struct PlayerBaseStats{
        public int health;
        public int defense;
        public int attack;
        public int movespeed;
    }
public class PlayerAttributes : MonoBehaviour
{


    public int maxHealth;
    public int currentHealth;
    public int defense;
    public int attack;
    public int moveSpeed;

    //public HealthBar hb;

    public BoxCollider2D boxCollider;

    private int bedroomSceneIndex = 3;

    // Start is called before the first frame update
    void Start()
    {

        String path = Application.dataPath + "/Scripts/Player/PlayerStats.json";

        PlayerBaseStats stats = getPermStatus();

        //Set all player attributes to their base values
        attack = stats.attack;
        maxHealth = stats.health;
        moveSpeed = stats.movespeed;
        defense = stats.defense;
        //Set all player attributes to their proper values
        //TODO: set these using the permanent counters in Scandrol_4
        // modifyDamage(/*TODO: FIll these in*/);
        // modifyMaxHealth();
        // modifyMoveSpeed();
        // modifyDefense();
        //hb.SetMaxHealth(maxHealth);
        setCurrentHealth(maxHealth);
    }


    // Update is called once per frame
    void Update()
    {
        // Tests, not to be live code
        if (Input.GetKeyDown(KeyCode.Space))
        {
            modifyCurrentHealth(-1);
        }
    }




    PlayerBaseStats getPermStatus()
    {
        string path = Application.dataPath + "/Scripts/Player/PlayerStats.json";

        string[] lines = File.ReadAllLines(path);
        string jsonStr = "";
        foreach (string line in lines) {
            jsonStr += line;
        }

        PlayerBaseStats stats = JsonUtility.FromJson<PlayerBaseStats>(jsonStr);

        return stats;
    }
  

    //Modifies the movement speed of the character by multiplying it by some float value.
    void modifyMoveSpeed(int mod)
    {
        moveSpeed *= mod;
    }

    //Modifies the base damage of the character by multiplying it by some float value.
    void modifyDamage(int mod)
    {
        attack *= mod;
    }


    //Modifies the base defense of the character by multiplying it by some float value.
    void modifyDefense(int mod)
    {
        defense *= mod;
    }

    //Modifies the max health of the character my multiplying it by some float value.
    void modifyMaxHealth(int mod)
    {
        maxHealth *= mod;
    }

    //Modifies the current health value by adding a certain float to it.
    void modifyCurrentHealth(int mod)
    {
        currentHealth += mod;
        //hb.SetHealth(currentHealth);
    }

    //Sets the current health to a desired value (used mainly for initialization of the character.)
    public void setCurrentHealth(int val)
    {
        if (val <= 0) {
            Debug.Log("Player Health cannot be Value: " + val);
        }
        else if(val>maxHealth)
        {
            currentHealth = maxHealth;
        }else
        {
            currentHealth = val;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            takeDamage(other.gameObject.GetComponent<EnemyAttributes>().getAttack());
        }
    }

    void takeDamage(int incomingDamage)
    {
        int damageTaken = incomingDamage - defense;
        if (damageTaken <= 0)
        {
            damageTaken = 1;
        }

        modifyCurrentHealth(-damageTaken);

        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameObject.FindGameObjectWithTag("FloorManager"));
        SceneManager.LoadSceneAsync(bedroomSceneIndex, LoadSceneMode.Single);
    }

    public int increaseAttackByPercent(double percent) {
        int increase = (int)Math.Ceiling((double)attack * percent);
        attack += increase;
        return attack;
    }

    public int increaseDefenseByPercent(double percent) {
        int increase = (int)Math.Ceiling((double)defense * percent);
        defense += increase;
        return defense;
    }

    public int increaseMaxHealthByPercent(double percent) {
        int increase = (int)Math.Ceiling((double)maxHealth * percent);
        maxHealth += increase;
        return maxHealth;
    }

    public int restoreHealthByPercent(double percent) {
        int restore = (int)Math.Ceiling((double)maxHealth * percent);

        if (restore + currentHealth >= maxHealth) {
            currentHealth = maxHealth;
        }
        else {
            currentHealth += restore;
        }

        return currentHealth;
    }
    
}
