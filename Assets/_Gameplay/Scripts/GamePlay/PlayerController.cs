using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;

    public GameObject StackParent;
    public GameObject MainStack;

    private Vector2 onePos;
    private Vector2 twoPos;
    public Vector2 textPos;

    public float moveSpeed = 20f;

    public List<GameObject> stack = new List<GameObject>();
    public static PlayerController Instance { get; private set; }
    private void Awake()
    {
        

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        SwipePlayer();
        
    }

    private void SwipePlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            twoPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            textPos = new Vector2( twoPos.x - onePos.x, twoPos.y - onePos.y );

            textPos.Normalize();
        }

        if (textPos.x > -0.5f && textPos.x < 0.5f)
        {
            if(textPos.y > 0) rb.velocity = Vector3.forward * moveSpeed;

            if(textPos.y < 0) rb.velocity = Vector3.back * moveSpeed;

        }
        
        else if (textPos.y > -0.5f && textPos.y < 0.5f)
        {
            if(textPos.x > 0) rb.velocity = Vector3.right * moveSpeed;

            if(textPos.x < 0) rb.velocity = Vector3.left * moveSpeed;
           
        }
      
    }
    public void PickStack(GameObject pick)
    {
        pick.transform.SetParent(StackParent.transform);
        Vector3 pos = MainStack.transform.localPosition;


        pos.y -= 0.25f;
        pick.transform.localPosition = pos;
        Vector3 Characterpos = transform.localPosition;


        Characterpos.y += 0.25f;
        transform.localPosition = Characterpos;

        MainStack = pick;
        MainStack.GetComponent<BoxCollider>().isTrigger = false;
        stack.Add(pick);

    }
    public void DropStack()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z);
        MainStack.transform.position = new Vector3(MainStack.transform.position.x, MainStack.transform.position.y + 0.25f, MainStack.transform.position.z);
        stack.RemoveAt(stack.Count - 1);
        Destroy(stack[stack.Count - 1]);
    }
   
    
}
