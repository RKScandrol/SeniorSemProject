using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{


    private Item item1;
    private Item item2;
    private Item item3;
    private LootTable lootTable;
    private bool isOpen;
    public GameObject contr;


    public Item getItem1() {
        return item1;
    }
    public Item getItem2() {
        return item2;
    }
    public Item getItem3() {
        return item3;
    }
    public bool isChestOpen() {
        return isOpen;
    }

   
    // Start is called before the first frame update
    void Start()
    {

        /*
            Unnecessary?
            Doesn't work, Unsure as to why, 
                NullReferenceException on lines for Item assignments below
                Code runs before GameController Script?

        */

        // GameController gc = contr.GetComponent<GameController>();
        // lootTable = gc.getLootTable();

        // this.item1 = lootTable.pickItem();
        // this.item2 = lootTable.pickItem();      //NOTE: add function to check for duplicates
        // this.item3 = lootTable.pickItem();      //NOTE: add function to check for duplicates
        
        this.isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
