using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FightHero : MonoBehaviour
{
    public static FightHero _instantion;

    [SerializeField] Image imageHealth;
    [SerializeField] Image imageTackle;
    [SerializeField] Image imageCatching;
    [SerializeField] Slider slider;
    [SerializeField] Sprite spriteLeft;
    [SerializeField] Sprite spriteRight;

    [Header("точки боя")]
    [SerializeField] RectTransform positionForFishing;
    [SerializeField] RectTransform positionForHook;
    [SerializeField] RectTransform positionForFight;

    [Header("Окно о конце игры"), SerializeField] GameObject windowEnd;

    [SerializeField] FightEnemyShip enemyShip;

    delegate void FightType();
    FightType Fight;

    [SerializeField] Image image;
    [SerializeField] GameObject hook;
    [SerializeField] GameObject harpun;

    private void Awake()
    {
        _instantion = this;
    }


    private void Start()
    {
        ChooseType();
    }

    public void ChooseType()
    {
        GetDataHero();

        if (enemyShip.enemy.type == TYPEENEMY.PIRATES)
        {
            Fight = Race;
        }
        if (enemyShip.enemy.type == TYPEENEMY.FISH)
        {
            Fight = Fishing;
        }
        else
        if (enemyShip.enemy.type == TYPEENEMY.BOSS)
        {
            Fight = Boss;
        }

        Fight();
    }

    public void GetDataHero()
    {
        float currentHealth = HeroData._instantion.currentHealth;
        float health = HeroData._instantion.health;

        imageHealth.fillAmount = currentHealth / health;

        float currentTackle = HeroData._instantion.currentTackle;
        float tackle = HeroData._instantion.tackle;
        imageTackle.fillAmount = currentTackle / tackle;
    }

    void GetDamge()
    {

    }

    // тягать их когда вошли в коллайдер
    void Race()
    {
        image.sprite = spriteLeft;
        StartCoroutine(StartRace());
    }

    void Fishing()
    {
        image.sprite = spriteRight;
        if (!hook.activeSelf)
            hook.SetActive(true);

        StartCoroutine(StartFishing());
        
    }

    void Boss()
    {
        image.sprite = spriteRight;
        if (!harpun.activeSelf)
        {
            harpun.SetActive(true);
        }

        StartCoroutine(StartBoss());
    }

    // гонка
    IEnumerator StartRace()
    {
        while (Vector3.Distance(GetComponent<RectTransform>().position, positionForFight.position) > 0.2f)
        {
            GetComponent<RectTransform>().position = Vector3.MoveTowards(GetComponent<RectTransform>().position, positionForFight.position, (HeroData._instantion.speed / 10f) * Time.deltaTime);
            yield return null;
        }

        while (slider.value < slider.maxValue)
        {
            slider.value += (HeroData._instantion.speed * Time.deltaTime) / 100f;

            yield return null;
        }
        DropInventoryItem._instantion.GetRandomItem();
        Destroy(enemyShip.enemy.gameObject);
        enemyShip.enemy = null;
        WindowFight._instantion.windowFight.gameObject.SetActive(false);
        

        yield break;
    }

    // ловля
    IEnumerator StartFishing()
    {
        System.Random random = new System.Random();
        while (Vector3.Distance(GetComponent<RectTransform>().position, positionForFishing.position) > 0.2f)
        {
            GetComponent<RectTransform>().position = Vector3.MoveTowards(GetComponent<RectTransform>().position, positionForFishing.position, (HeroData._instantion.speed / 10f) * Time.deltaTime);
            yield return null;
        }

        while (enemyShip.enemy)
        {
            
            if (Vector3.Distance(hook.GetComponent<RectTransform>().position, positionForHook.position) > 0.2f)
            {
                hook.GetComponent<RectTransform>().position = Vector3.MoveTowards(hook.GetComponent<RectTransform>().position, positionForHook.position, HeroData._instantion.catchingScore * Time.deltaTime);
            }
            else
            {
                hook.GetComponent<RectTransform>().position = positionForFishing.position;
                yield return new WaitForSeconds(3);
                enemyShip.enemy.currentHealth -= random.Next(HeroData._instantion.minDamage, HeroData._instantion.maxDamage);
                HeroData._instantion.currentTackle -= 1;
            }
            HeroData._instantion.Notify();

            if(enemyShip.enemy.currentHealth < 0)
            {
                HeroData._instantion.countFish += random.Next(10, enemyShip.enemy.health / 2);

                DropInventoryItem._instantion.GetRandomItem();
                TileController._instantion.GetRandomCard();
                enemyShip.enemy = null;
            }
            yield return null;
        }

        enemyShip.enemy = null;
        WindowFight._instantion.windowFight.gameObject.SetActive(false);
        yield break;
    }

    // бой с боссом
    IEnumerator StartBoss()
    {
        System.Random random = new System.Random();

        while (Vector3.Distance(GetComponent<RectTransform>().position, positionForFishing.position) > 0.2f)
        {
            GetComponent<RectTransform>().position = Vector3.MoveTowards(GetComponent<RectTransform>().position, positionForFishing.position, (HeroData._instantion.speed / 10f) * Time.deltaTime);
            yield return null;
        }

        float agile = 0;
        while (enemyShip.enemy)
        {
            agile += (HeroData._instantion.speed / 10f) * Time.deltaTime;
            imageCatching.fillAmount += agile / HeroData._instantion.speed;

            if (imageCatching.fillAmount >= 1)
            {
                while(Vector3.Distance(harpun.GetComponent<RectTransform>().position, positionForHook.position) > 0.2f)
                { 
                
                    harpun.GetComponent<RectTransform>().position = Vector3.MoveTowards(harpun.GetComponent<RectTransform>().position, positionForHook.position, HeroData._instantion.catchingScore * Time.deltaTime);
                    yield return null;
                }
                harpun.GetComponent<RectTransform>().position = positionForFishing.position;
                enemyShip.enemy.currentHealth -= random.Next(HeroData._instantion.minDamage, HeroData._instantion.maxDamage);
                HeroData._instantion.currentTackle -= 1;
                agile = 0;
            }
            HeroData._instantion.Notify();

            if (enemyShip.enemy.currentHealth < 0)
            {
                HeroData._instantion.countFish += random.Next(10, enemyShip.enemy.health / 2);

                DropInventoryItem._instantion.GetRandomItem();
                TileController._instantion.GetRandomCard();
                Destroy(enemyShip.enemy);
            }
            yield return new WaitForSeconds(2);
            yield return null;
        }
        enemyShip.enemy = null;
        WindowFight._instantion.windowFight.gameObject.SetActive(false);
        windowEnd.SetActive(true);

        yield break;
    }
}
