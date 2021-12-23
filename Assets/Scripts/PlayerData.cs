using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;

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
    }

    private int _strength;
    private int _weigth;
    private int _speed;
    private int _health;
    public int Strength => _strength;
    public int Weigth => _weigth;
    public int Speed => _speed;
    public int Health => _health;

    public void SetStrength(int str)
    {
        _strength = str;
    }

    public void SetWeigth(int wgt)
    {
        _weigth = wgt;
    }

    public void SetSpeed(int spd)
    {
        _speed = spd;
    }

    public void SetHealth(int hp)
    {
        _health = hp;
    }
}
