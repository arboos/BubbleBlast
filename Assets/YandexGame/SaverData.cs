using System;
using TMPro;
using UnityEngine;
using YG;

public class SaverData : MonoBehaviour
{

    // Подписываемся на событие GetDataEvent в OnEnable
    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

// Отписываемся от события GetDataEvent в OnDisable
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void Start()
    {
        // Проверяем запустился ли плагин
        if (YandexGame.SDKEnabled == true)
        {
            // Если запустился, то выполняем Ваш метод для загрузки
            GetLoad();

            // Если плагин еще не прогрузился, то метод не выполнится в методе Start,
            // но он запустится при вызове события GetDataEvent, после прогрузки плагина
        }
    }

// Ваш метод для загрузки, который будет запускаться в старте
    public void GetLoad()
    {
        //RecordManager.Instance.BestRecordLine.transform.position =
            //new Vector2(YandexGame.savesData.bestFlag, 0);


            UI_Menu.Instance.LevelsReached = YandexGame.savesData.levelsReached;

            //Gameplay

            // Получаем данные из плагина и делаем с ними что хотим
            // Например, мы хотил записать в компонент UI.Text сколько у игрока монет:
            //textMoney.text = YandexGame.savesData.money.ToString();
    }

    // Допустим, это Ваш метод для сохранения
    public void MySave()
    {
        // Записываем данные в плагин
        // Например, мы хотил сохранить количество монет игрока:
        //YandexGame.savesData.money = money;

        // Теперь остаётся сохранить данные
        YandexGame.SaveProgress();
    }

    private void OnApplicationQuit()
    {
        YandexGame.SaveProgress();
    }
}
