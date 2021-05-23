using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightEnemyShip : MonoBehaviour
{
    public static FightEnemyShip _instantion;

    [SerializeField] FightHero hero;
    [SerializeField] Slider slider;
    [SerializeField] GameObject windowRace;
    [SerializeField] Image imageAgility;
    [SerializeField] Image imageHealth;

    [SerializeField] Animator animatorHero;
    [SerializeField] Image sprite;
    [SerializeField] RectTransform positionFish;
    [SerializeField] RectTransform positionFight;

    // получить все данные из enemy


    public EnemyType enemy;

    delegate void typeFight();
    typeFight Fight;

    private void Awake()
    {
        _instantion = this;
    }

    private void Start()
    {

        GetTypeEnemy();

    }

    public IEnumerator StartBase()
    {
        GetTypeEnemy();
        Fight();

        yield break;
    }

    public void GetTypeEnemy()
    {
        Debug.Log(enemy.type.ToString());
        if(enemy.type == TYPEENEMY.PIRATES)
        {
            Fight = Race;
        }
        else
        if(enemy.type == TYPEENEMY.FISH)
        {
            Fight = Fishing;
        } 
        else
            if(enemy.type == TYPEENEMY.BOSS)
        {
            Fight = Boss;
        }
        Fight();

    }

    void Race()
    {
        if (!windowRace.activeSelf)
        {
            windowRace.SetActive(true);
        }
        System.Random random = new System.Random();
        sprite.sprite = enemy.sprite;
        StartCoroutine(RaceTime(random));

    }

    void Fishing()
    {
        GetComponent<RectTransform>().position = positionFish.position;
        if (windowRace.activeSelf)
        {
            windowRace.SetActive(false);
        }

        if (enemy)
        sprite.sprite = enemy.sprite;

        StartCoroutine(StartFishing());
    }

    void Boss()
    {
        GetComponent<RectTransform>().position = positionFish.position;
        if (windowRace.activeSelf)
        {
            windowRace.SetActive(false);
        }

        if (enemy)
            sprite.sprite = enemy.sprite;

        StartCoroutine(StartBoss());

    }


    IEnumerator RaceTime(System.Random random)
    {

        while(Vector3.Distance(GetComponent<RectTransform>().position, positionFight.position) > 0.2f)
        {
            GetComponent<RectTransform>().position = Vector3.MoveTowards(GetComponent<RectTransform>().position, positionFight.position, (enemy.speed / 10) * Time.deltaTime);
            yield return null;
        }

        float tempSpeed = enemy.speed;
        float agility = 0;
        while (slider.value < slider.maxValue || enemy)
        {
            agility += (enemy.speed / 10)* Time.deltaTime;
            imageAgility.fillAmount = agility / enemy.speed;
            slider.value += (enemy.speed * Time.deltaTime)/ 100f;

            if (imageAgility.fillAmount >= 1)
            {
                agility = 0;
                HeroData._instantion.currentHealth -= random.Next(enemy.minDamage, enemy.maxDamage);
                animatorHero.SetBool("Hit", true);
                HeroData._instantion.Notify();

                hero.GetDataHero();
                tempSpeed = enemy.speed;
            }

            yield return null;
        }
        if (slider.value == slider.maxValue && enemy)
        {
            HeroData._instantion.currentTackle -= random.Next(enemy.minDamage, enemy.maxDamage);
            HeroData._instantion.Notify();
        }

        enemy = null;
        yield break;
    }

    IEnumerator StartFishing()
    {
        float agility = 0;
        System.Random random = new System.Random();
        // либо забрать часть снастей, либо убежать 35 / 65
        while(enemy.currentHealth > 0 || enemy.health > 0)
        {
            agility += (enemy.speed / 10) * Time.deltaTime;
            imageAgility.fillAmount = agility / enemy.speed;

            if (imageAgility.fillAmount >= 1)
            {
                agility = 0;
                var chance = random.Next(0, 100);

                if (chance < 35)
                {
                    HeroData._instantion.currentHealth -= random.Next(enemy.minDamage, enemy.maxDamage);
                }
                else
                {
                    HeroData._instantion.currentTackle -= random.Next(enemy.minDamage, enemy.maxDamage);
                }
            }
            HeroData._instantion.Notify();
            imageHealth.fillAmount = (float)enemy.currentHealth / (float)enemy.health;
            yield return null;
        }
        enemy = null;
        yield break;
    }


    IEnumerator StartBoss()
    {
        float agility = 0;
        System.Random random = new System.Random();

        while (enemy.currentHealth > 0 || enemy.health > 0)
        {
            agility += (enemy.speed / 10) * Time.deltaTime;
            imageAgility.fillAmount = agility / enemy.speed;

            if (imageAgility.fillAmount >= 1)
            {
                agility = 0;
                HeroData._instantion.currentHealth -= random.Next(enemy.minDamage, enemy.maxDamage);
            }
            HeroData._instantion.Notify();
            imageHealth.fillAmount = (float)enemy.currentHealth / (float)enemy.health;
            yield return null;
        }
        yield break;
    }
}
