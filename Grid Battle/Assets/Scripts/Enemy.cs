using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Player player;
    Slot slot;
    [SerializeField]
    private GameObject mainCharacter;
    [SerializeField]
    private int damage,health;
   // private int populater = 0;
    private int[] pattern = new int[9]{ 1, 0, 1, 0, 1,0,1,0,1};
    [SerializeField]
    private List<GameObject> targets;
    [SerializeField]
    private float timer;
    [SerializeField]
    private bool attack = false;
    [SerializeField]
    private bool end = false;
    // Start is called before the first frame update
    void Start()
    {
        player = mainCharacter.GetComponent<Player>();
        targets = player.slots;
       for (int i = 0; i > player.slots.Count; i++)
        {
            //targets.Add(player.slots[i]);
            slot = targets[i].GetComponent<Slot>();
            //Debug.Log(slot.POS_X + slot.POS_Y);

           // populater++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //targets = player.Slots();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack = true;
            StartAttack(pattern, 3f);
        }
        if(attack)
        { 
            timer -= Time.deltaTime;
            //Debug.Log(timer);
            if (timer <= 0)
            {
                Attack(pattern, 3);
                attack = false;
               // end = true;
            }          
        }
    }
  
    private void Attack(int[] attack, int harm)
    {
        for(int i =0;i <  attack.Length; i++)
        {
            //Debug.Log(attack[i]);
            slot = targets[i].GetComponent<Slot>();
            slot.SetActive(attack[i]);
        }
    }

    private void StartAttack(int[] attack, float time)
    {
        timer = time;
            for (int i = 0; i < attack.Length; i++)
            {
                //Debug.Log(attack[i]);
                slot = targets[i].GetComponent<Slot>();
                slot.SetWarning(attack[i]);
           }
    }

   private void EndAttack()
    {
       if(end)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                //Debug.Log(attack[i]);
                slot = targets[i].GetComponent<Slot>();
                slot.SetNeutral();
            }
        }
       
    }    
}
