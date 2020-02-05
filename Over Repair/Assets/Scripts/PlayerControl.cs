﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl Instance { get; private set; }

    public AudioManager audioManager;
    public ItemManager itemManager;
    public PlayerSpriteController playerSpriteController;
    private GameObject RobotDown;
    public Main main;
    public Joystick joystick;
    public Data data;
    public GameObject BlindEffect;

    public bool[] MyStates;

    private float MaxSpeed = 1f;
    private float Speed;
    private int ItemID;
    public int Item1 = 8;
    public int Item2 = 8;
    public bool isBlind = false;
    private int HandCount = 0;
    public bool isMoving { get; private set; }
    public Vector2 direction { get; private set; }
    public bool isPlaying = true;
    private int BreakProbability;
    
    void Awake()
    {
        Instance = this;
        MyStates = new bool[] { true, true, true, true, true, true };
    }

    public void Init(bool[] parts)
    {
        Item1 = 8;
        Item2 = 8; 
        MaxSpeed = data.PlayerInitSpeed;
        HandCount = 0;

        isBlind = !parts[0];
        if (parts[1]) HandCount++;
        if (parts[2]) HandCount++;
        if (parts[3]) MaxSpeed += data.PlayerFootSpeed;
        if (parts[4]) MaxSpeed += data.PlayerFootSpeed;
        if (!parts[5]) isPlaying = false;

        playerSpriteController.SetPart(parts);

        MyStates = parts;
    }

    public void CheckBlind()
    {
        if (isBlind)
        {
            BlindEffect.SetActive(true);
            BlindEffect.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, data.PlayerBlindLevel);
        }
        else BlindEffect.SetActive(false);
    }

    public bool[] Remain()
    {
        BreakProbability = Mathf.Clamp(data.PlayerBreakConstant * main.gameRound, 0, data.PlayerMaxBreakProbability);
        for(int i = 0; i < MyStates.Length; i++)
        {
            if (MyStates[i] && Random.Range(0, 100) < BreakProbability) MyStates[i] = false;
        }
        MyStates[5] = false;
        return MyStates;
    }

    void Update()
    {
        Walk();
    }

    private void Walk()
    {
        Vector2 movement = Vector2.zero;

        if (isPlaying)
        {
            if (Input.GetKey(KeyCode.W)) movement += Vector2.up;
            if (Input.GetKey(KeyCode.A)) movement += Vector2.left;
            if (Input.GetKey(KeyCode.S)) movement += Vector2.down;
            if (Input.GetKey(KeyCode.D)) movement += Vector2.right;
            Speed = MaxSpeed;
            if (joystick.isDragging)
            {
                movement = joystick.movement;
                Speed = joystick.Speed * MaxSpeed;
            }
        }

        if(movement == Vector2.zero)
        {
            if (isMoving)
            {
                isMoving = false;
                audioManager.Pause("walk");
            }
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        else
        {
            if (!isMoving)
            {
                isMoving = true;
                audioManager.Play("walk", true);
            }
            GetComponent<Rigidbody2D>().velocity = movement.normalized * Speed;
        }
        direction = movement;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isPlaying)
        {
            if (collision.tag == "Item")
            {
                ItemController itemController = collision.gameObject.GetComponent<ItemController>();
                if (itemController)
                {
                    ItemID = itemController.ID;
                    if (Item1 == 8 && HandCount >= 1)
                    {
                        Item1 = ItemID;
                        itemManager.PickItem(itemController);
                        audioManager.Play("pick");
                    }
                    else if (Item2 == 8 && HandCount >= 2)
                    {
                        Item2 = ItemID;
                        itemManager.PickItem(itemController);
                        audioManager.Play("pick");
                    }
                }
            }

            if (collision.tag == "TrashCan")
            {
                if(Item1 != 8 || Item2 != 8) audioManager.Play("trash");
                Item1 = 8;
                Item2 = 8;
            }

            if (collision.tag == "RobotDown")
            {
                bool gived = false;
                if (collision.GetComponentInParent<RobotDown>().InterActByPlayer(Item1))
                {
                    Item1 = Item2;
                    Item2 = 8;
                    gived = true;
                }
                if (collision.GetComponentInParent<RobotDown>().InterActByPlayer(Item2))
                {
                    Item2 = 8;
                    gived = true;
                }

                if (gived)
                    audioManager.Play("give");
            }
        }
    }
}
