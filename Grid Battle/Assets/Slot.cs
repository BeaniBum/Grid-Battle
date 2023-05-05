using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField]
    public int POS_X;
    [SerializeField]
    public int POS_Y;
    [SerializeField]
    private Material neutral,warning,bad,current;
    [SerializeField]
    private MeshRenderer renderer;
    [SerializeField]
    private float refresh = 3f;

    public Vector3 position = new Vector3();
    public bool active = false;

    
        

    // Start is called before the first frame update
    void Start()
    {
        current = neutral;
       position = transform.position;
//Debug.Log(position);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (current == bad)
        {
            Debug.Log("fwoosh");
            refresh -= Time.deltaTime;
            Debug.Log(refresh);
            if (refresh <= 0)
                renderer.material = neutral;

        }
    }
    public Vector3 Position()
    {
        return position;
    }
    public void SetActive(int value)
    {
        if(value==1)
        {
            active = true;
            renderer.material = bad;
            current = bad;
        }
    }
    public void SetWarning(int value)
    {
        if (value == 1)
        {
            //active = true;
            renderer.material = warning;
            current = warning;
        }
    }
    public void SetNeutral()
    {
        renderer.material = neutral;
        current = neutral;
    }
}
