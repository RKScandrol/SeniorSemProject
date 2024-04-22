using System;
using UnityEngine;

[Serializable]public class Freeze : Item
{

    private DateTime activationTime;
    [SerializeField]private double timeIncrement;          //Time between freezes, in Minutes
    [SerializeField]private int effectTime;             //Freeze Duration, in Seconds

    private float enemyPreviousMoveSpeed;
    private GameObject frozenEnemy;
    private int numTimesIntensified;

    public Freeze(int itemID, string name, string description, int weight, 
    double timeIncrement, int effectTime) : 
    base(itemID, name, description, weight)
    {
        this.timeIncrement = timeIncrement;
        this.effectTime = effectTime;
        this.enemyPreviousMoveSpeed = -1;
        this.frozenEnemy = null;
        this.numTimesIntensified = 0;
    }

    public Freeze(int itemID, string name, string description, int weight, int minWeight, int maxWeight, 
    DateTime activationTime, double timeIncrement, int effectTime) : 
    base(itemID, name, description, weight, minWeight, maxWeight)
    {
        this.activationTime = activationTime;
        this.timeIncrement = timeIncrement;
        this.effectTime = effectTime;
        this.enemyPreviousMoveSpeed = -1;
        this.frozenEnemy = null;
        this.numTimesIntensified = 0;
    }

    

    public override DateTime getActivationTime()
    {
        return activationTime;
    }

    public override string getDescription()
    {
        return description + "\nFreeze Effect Time: " + effectTime + " seconds.\nWait Time: " + timeIncrement + " minutes.";
    }

    public override string getIconPath()
    {
        return "Assets/Graphics/ItemIcons/FreezeIcon.png";
    }
    

    
    public override void initializeItem()
    {
        activationTime = DateTime.Now.AddMinutes(timeIncrement);

        ItemClock itemClock = GameObject.Find("Clock").GetComponent<ItemClock>();
        itemClock.addItem(this);
    }

    public override void activateItem()
    {
        //If there is no current frozen enemy
        if (frozenEnemy == null) {
            //get Enemies
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            //Closest distance is auto set to max value
            float closestDist = float.MaxValue;
            //Player position
            Vector2 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            //Check for closest enemy that is also visable in the camera
            foreach (GameObject enemy in enemies) {
                SpriteRenderer spriteRenderer = enemy.transform.GetComponentInChildren<SpriteRenderer>();
                float distance = Vector2.Distance(playerPos, enemy.transform.position);
                
                if (distance < closestDist && spriteRenderer.isVisible) {
                    closestDist = distance;
                    frozenEnemy = enemy;
                }
                
            }
            //If there is an enemy visible in the camera
            if (frozenEnemy != null) {
                //Record current enemy move speed then set to 0
                EnemyAI enemyAI = frozenEnemy.GetComponent<EnemyAI>();
                enemyPreviousMoveSpeed = enemyAI.moveSpeed;
                enemyAI.moveSpeed = 0;
                Debug.Log(frozenEnemy.name + " frozen");
                //Play Freeze Animation for Enemy
                Animator animator = frozenEnemy.transform.Find("Freeze").GetComponent<Animator>();
                animator.Play("FreezeAnimation");
                //Increment Activation Time by Effect Time
                activationTime = activationTime.AddSeconds(effectTime);
            }
            //If there is not an enemy in the camera
            else {
                //Increment Activation Time by Time Increment
                activationTime = activationTime.AddMinutes(timeIncrement);

                Debug.Log("No enemy Frozen");
            }
            

        }
        //If there is a Enemy Currently Frozen
        else {
            //Reset Enemy Move Speed
            EnemyAI enemyAI = frozenEnemy.GetComponent<EnemyAI>();
            enemyAI.moveSpeed = enemyPreviousMoveSpeed;
            //Increment Activation Time
            activationTime = activationTime.AddMinutes(timeIncrement);

            Debug.Log(frozenEnemy.name + " unfrozen");
            //Set Frozen Enemy to null
            frozenEnemy = null;
        }
    }

    public override void intensify()
    {
        if (numTimesIntensified % 2 == 0 || timeIncrement <= 1.0) {
            effectTime += 2;
        }
        else {
            if (timeIncrement >= 1.5) {
                timeIncrement -= 0.5;
            }
            else if (timeIncrement >= 1.0) {
                timeIncrement = 1.0;
            }
        }

        numTimesIntensified++;
    }
}
