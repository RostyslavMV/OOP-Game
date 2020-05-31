using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TreasureChest : Interactable
{
    [Header("Contents")]
    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public BoolValue storedOpen;
    [Header("Signals and Dialogs")]
    public Signal raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    [Header("Animation")]
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        isOpen = storedOpen.RuntimeValue;
        if (isOpen)
        {
            anim.SetBool("Opened", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if (!isOpen)
            {
                //Open chest
                openChest();
            }
            else
            {
                //Chest is already opened
                chestOpenedAlready();
            }
        }
    }
    public void openChest()
    {
        //Dialog window on
        dialogBox.SetActive(true);
        dialogText.text = contents.itemDescription;
        //add to the inventory
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        //Raise the signal to animate 
        raiseItem.Raise();
        //set chest to opened
        isOpen = true;
        storedOpen.RuntimeValue = true;
        //raise the context clue
        Context.Raise();
        anim.SetBool("Opened", true);
    }
    public void chestOpenedAlready()
    {
        //Dialog off
        dialogBox.SetActive(false);
        //raise the signal to the player to stop animating
        raiseItem.Raise();
        playerInRange = false;

    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger &&!isOpen)
        {
            Context.Raise();
            playerInRange = true;

        }
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && !isOpen)
        {
            Context.Raise();
            playerInRange = false;
        }
    }
}
