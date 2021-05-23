using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroData : MonoBehaviour, ISubject
{
    public static HeroData _instantion;

    public int health;          // Жизни
    public int currentHealth;

    public int tackle;          // Снасти
    public int currentTackle;

    public int speed;           // Скорость

    public int catchingScore;   // Очки ловли

    public int minDamage;          // Урон
    public int maxDamage;          // Урон

    public int criticalChance;  // Шанс критического урона

    public bool pause;

    public int countFish;

    List<int> damages = new List<int>();

    List<IObserver> observers = new List<IObserver>();


    

    public void Atach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);

    }

    public void Notify()
    {
        foreach (var item in observers)
        {
            item.StateUpdate(this);
        }
    }

    private void Awake()
    {
        _instantion = this;
    }

    
    

}
