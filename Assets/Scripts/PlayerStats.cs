using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    public static int Money;
    public int startMoney = 400;

    void Awake()
    { 
        instance = this;
    }

    void Start()
    {
        Money = startMoney;
    }

    public void adjustMoney(int money)
    {
        Money += money;
    }
}
