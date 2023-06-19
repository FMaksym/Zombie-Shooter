using System;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public delegate void BankHendler(object sender, int OldCoinValue, int newCoinsValue);
    public event BankHendler OnCoinValueChangedEvent;
    public event Action<object, int, int> OnCoinValueChangedActionEvent;

    public int coins { get => coins; 
        set {
            coins = PlayerPrefs.GetInt("Coins");
            } 
    }

    public void AddCoins(object sender, int amount){
        var oldCoinsValue = coins;
        coins += amount;
        PlayerPrefs.SetInt("Coins", coins);

        OnCoinValueChangedEvent?.Invoke(sender, oldCoinsValue, coins);
        OnCoinValueChangedActionEvent?.Invoke(sender, oldCoinsValue, coins);
    } 
    public void SpendCoins(object sender, int amount)
    {
        var oldCoinsValue = coins;
        coins -= amount;
        PlayerPrefs.SetInt("Coins", coins);

        OnCoinValueChangedEvent?.Invoke(sender, oldCoinsValue, coins);
        OnCoinValueChangedActionEvent?.Invoke(sender, oldCoinsValue, coins);
    }

    public bool IsEnought(int amount) {

        coins = PlayerPrefs.GetInt("Coins");
        return coins >= amount;
    } 
}
