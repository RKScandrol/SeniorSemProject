using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{


    private Item item1;
    private Item item2;
    private Item item3;
    public LootTable lootTable;
    private bool isOpen;


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
        this.item1 = lootTable.pickItem();
        this.item2 = lootTable.pickItem();
        this.item3 = lootTable.pickItem();
        this.isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
