using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public static DiceManager instance;
    public Transform spawn;
    public GameObject dice;
    int fillIndex;
    private void Start()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        fillIndex = 0;
    }

    public void SpawnDice()
    {
        var newDice = Instantiate(dice, spawn);
        newDice.GetComponentInChildren<Dice>().diceManager = this;
    }

    public void ReceiveValues(int value)
    {
        switch(fillIndex)
        {
            case 0:
                PlayerData.instance.SetStrength(value);
                fillIndex++;
                break;
            case 1:
                PlayerData.instance.SetWeigth(value);
                fillIndex++;
                break;
            case 2:
                PlayerData.instance.SetSpeed(value);
                fillIndex++;
                break;
            case 3:
                PlayerData.instance.SetHealth(value);
                fillIndex = 0;
                break;
        }
    }
}
