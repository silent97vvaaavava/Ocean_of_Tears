using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// двигается про траектории
public class MovmentHero : MonoBehaviour, ISubject
{
    [Header("Спрайты для движения")]
    [SerializeField] Sprite[] sprites;

    //[Range(1, 10)] public int speed; // скорость игрока (перенести в характеристики игрока)

    //bool start = false; // чек для паузы
    [SerializeField] Button pauseBtn;   // кнопка для паузы

    private List<Vector3> points = new List<Vector3>(); // список точек

    private int nextPoint = 0; // переменная хранящая номер текущей точки

    private float currentLength;
    private float lastLength;
    private float deltaLength;

    SpriteRenderer spriteHero;

    public float CurrentLength { get => currentLength; }

    // При старте получаем все точки
    private void Start()
    {
        spriteHero = GetComponent<SpriteRenderer>();
        transform.position = points[nextPoint];
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PauseMovment();
        }
        if (!HeroData._instantion.pause) return;
        else
        {
            DirectionSprite(nextPoint);
            Movement();
        }
    }

    /// <summary>
    /// Передвижение от точки к точке
    /// </summary>
    void Movement()
    {
        //transform.position = Vector3.MoveTowards(transform.position, points[nextPoint % points.Count], speed * Time.deltaTime);
        //deltaLength = Vector3.Distance(points[(nextPoint - 1) % points.Count], transform.position);

        //currentLength = lastLength + deltaLength;
        if(Vector3.Distance(transform.position, points[nextPoint % points.Count]) < 0.2f)
        {
            nextPoint++;
            lastLength += deltaLength;
        }
        if((nextPoint % points.Count) == 1)
        {
            lastLength = 0;
        }
        transform.position = Vector3.MoveTowards(transform.position, points[nextPoint % points.Count], (HeroData._instantion.speed / 10) * Time.deltaTime);
        deltaLength = Vector3.Distance(points[(nextPoint - 1) % points.Count], transform.position);

        currentLength = lastLength + deltaLength;
        Notify();
    }

    /// <summary>
    /// Ставит на паузу движение
    /// </summary>
    void PauseMovment()
    {
        HeroData._instantion.pause = !HeroData._instantion.pause;
    }

    /// <summary>
    /// Получить данные для движения
    /// </summary>
    /// <param name="getPoints">Массив точек</param>
    /// <param name="button">кнопка для обработки события</param>
    public void SetPoints(List<Vector3> getPoints, Button button)
    {
        points = getPoints;
        pauseBtn = button;
        pauseBtn.onClick.AddListener(() => PauseMovment());
    }


    void DirectionSprite(int numberPoint)
    {
        var tempPoint = points[numberPoint % points.Count];
        var currentPosition = transform.position;
        if (currentPosition.y > tempPoint.y && currentPosition.x < tempPoint.x)
        {
            spriteHero.sprite = sprites[0];
            spriteHero.flipX = false;
        }
        else
        if (currentPosition.y > tempPoint.y && currentPosition.x > tempPoint.x)
        {
            spriteHero.sprite = sprites[0];
            spriteHero.flipX = true;
        }
        else
        if (currentPosition.y < tempPoint.y && currentPosition.x < tempPoint.x)
        {
            spriteHero.sprite = sprites[1];
            spriteHero.flipX = false;
        }
        else
        {
            spriteHero.sprite = sprites[1];
            spriteHero.flipX = true;
        }
    }

    public void Atach(IObserver observer)
    {

    }

    public void Detach(IObserver observer)
    {

    }

    public void Notify()
    {
        ScoreCircle._instantion.StateUpdate(this);
    }
}
