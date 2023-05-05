using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Slot tile; 
    [SerializeField]
    public List<GameObject> slots = new List<GameObject>();
    [SerializeField]
    private GameObject startSlot;
    [SerializeField]
    private GameObject currentSlot;
    [SerializeField]
    private int posX, posY;
    [SerializeField]
    private int health;

    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        tile = startSlot.GetComponent<Slot>();
        currentSlot = startSlot;
        
        position = this.transform.position;
        Debug.Log(position);
        
        posX = tile.POS_X;
        posY = tile.POS_Y;
        Sort();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Down");
            Move("Down");      
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Up");
            Move("Up"); 
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Left");
            Move("Left");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Right");
            Move("Right");
        }
    }
    private void Sort()
    {
        foreach (GameObject slot in slots)
        {
            tile = slot.GetComponent<Slot>();
            if (posX == tile.POS_X && posY == tile.POS_Y)
            {
                currentSlot = slot;
               // Debug.Log(slot.GetComponent<Slot>().position);
               position = tile.transform.position;
                transform.position = new Vector3(position.x, this.transform.position.y,position.z);
                
                //Debug.Log(position);
            }
        }
    }
    private void Move( string input)
    {
        if(input =="Down" )
        {
            if (posY > 0)
            {
                posY--;
                Sort();
            }
        }
        else if(input == "Up")
        {
            if (posY < 2)
            {
                posY++;
                Sort();
            }
        }
        else if(input == "Left")
        {
            if (posX > 0)
            {
                posX--;
                Sort();
            }
        }
        else if(input == "Right")
        {
            if (posX < 2)
            {
                posX++;
                Sort();
            }
        }
    }
    public List<GameObject> Slots()
    {
        return slots;
    }

    // private void MoveCheck
    /* foreach (GameObject slot in slots)
  {
      Debug.Log(slot.transform.position);
  }*/
}
