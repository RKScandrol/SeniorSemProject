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
    private int bubbleHealth;
    public int defense;
    public int attack;
    public int moveSpeed;
    public int gold;
    private GoldUISystem goldUISystem;
    private string goldJsonPath;

    //public HealthBar hb;

    public BoxCollider2D boxCollider;
    private bool isTakingDamage = false;

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


        goldJsonPath = "/Scripts/Player/Gold.json";
        readGoldFromJson();
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

    public void readGoldFromJson() {

        string jsonStr = File.ReadAllText(Application.dataPath + goldJsonPath);
        int[] golds = JsonHelper.FromJson<int>(jsonStr);
        gold = golds[0];

        

    }

    public void writeGoldToJson() {
        int[] golds = new int[1];
        golds[0] = gold;
        string jsonStr = JsonHelper.ToJson<int>(golds, true);
        File.WriteAllText(Application.dataPath + goldJsonPath, jsonStr);
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

    public void increaseCurrentHealthByPoints(int points) {
        if (points <= 0) {
            Debug.Log("Player Health cannot be increased by value: " + points);
        }
        else if (currentHealth + points > maxHealth) {
            currentHealth = maxHealth;
        }
        else {
            currentHealth += points;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy" && !isTakingDamage)
        {
            Vector2 direction = (gameObject.transform.position - other.transform.position).normalized;
            gameObject.GetComponent<Rigidbody2D>().AddForce(direction * 1000);
            StartCoroutine(takeDamage(other.gameObject.GetComponent<EnemyAttributes>().getAttack()));
        }
    }

    IEnumerator takeDamage(int incomingDamage)
    {
        isTakingDamage = true;
        //Freezes game for short time on taking damage("hitstop" effect)
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.1f);

        int damageTaken = incomingDamage - defense;
        if (damageTaken <= 0)
        {
            damageTaken = 1;
        }

        //If bubbleHealth is greater than 0
        if (bubbleHealth > 0) {
            //If bubbleHealth is greater than or equal to damageTaken
            if (bubbleHealth >= damageTaken) {
                //Decrease bubbleHealth by damageTaken
                bubbleHealth -= damageTaken;
                //Set damageTaken to 0
                damageTaken = 0;
            }
            //If damageTaken is greater than bubbleHealth
            else {
                //Decrease damage taken by bubbleHealth
                damageTaken -= bubbleHealth;
                //Set bubbleHealth to 0
                bubbleHealth = 0;
            }
            // Debug.Log("Bubble Health: " + bubbleHealth);
        }

        modifyCurrentHealth(-damageTaken);

        //Player dies if health below zero
        if (currentHealth <= 0)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            writeGoldToJson();
            GameObject.FindGameObjectWithTag("LevelChange").GetComponent<Animator>().SetTrigger("Death");
        }
        else {
            Time.timeScale = 1;
        }

        //Brief invulnerability after taking damage
        yield return new WaitForSecondsRealtime(0.5f);
        isTakingDamage = false;
    }


    public int increaseAttackByPercent(double percent) {
        int increase = (int)Math.Ceiling((double)attack * percent);
        attack += increase;
        return attack;
    }
    public int increaseAttackByPoints(int points) {
        attack += points;
        return attack;
    }
    public int decreaseAttackByPoints(int points) {
        int attackPointsTaken = 0;
        if (attack - points < 1) {
            attackPointsTaken = attack - 1;
            attack = 1;
        }
        else {
            attackPointsTaken = points;
            attack -= points;
        }
        return attackPointsTaken;
    }

    public int increaseDefenseByPercent(double percent) {
        int increase = (int)Math.Ceiling((double)defense * percent);
        defense += increase;
        return defense;
    }

    /*
        Decreases Defense stat by a given Percent
        Returns the amount the Defense was decreased by
    */
    public int decreaseDefenseByPercent(double percent) {
        int min = 1;
        int decrease = (int)Math.Ceiling((double)defense * percent);
        if (defense == min) {
            return 0;
        }
        else if (defense - decrease < min) {
            int ret = defense - min;
            defense = min;
            return ret;
        }
        else {
            defense -= decrease;
            return decrease;
        }
    }
    public int increaseDefenseByPoints(int points) {
        defense += points;
        return defense;
    }
    public int decreaseDefenseByPoints(int points) {
        if (defense - points <= 1) {
            defense = 1;
        } 
        else {
            defense -= points;
        }
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


    public int addBubbleHealth(int additionalBubbleHealth) {
        bubbleHealth += additionalBubbleHealth;
        return bubbleHealth;
    }

    public void increaseGold(int increase) {
        gold += increase;

        goldUISystem = GameObject.Find("GoldUI").GetComponent<GoldUISystem>();
        goldUISystem.setText(gold);
    }

    public int getGold() {
        return gold;
    }
    
}
