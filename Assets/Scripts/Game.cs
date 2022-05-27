using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Game : MonoBehaviour {
    public GameObject FullCookie;
    public GameObject CrackedCookie;
    public GameObject TextField;
    public GameObject InfoField;

    private float PassedTime = 0.0f;
    private bool IsCracked = false;
    private int FramesPassed = 0;

    private List<string> Predictions = new List<string> {
        //хорошие
        "Удача - ваша спутница.",
        "Долги будут возвращены.",
        "Ждите неожиданных деньжат.",
        "Найдете то, что ищете.",
        "Ждите хорошую новость.",
        "Избежите неприятностей.",
        "Появится вдохновение.",
        "Заведете полезное знакомство.",
        "Избежите ошибок.",
        "Труд будет оценен.",
        "Хорошо проведете время.",
        "Ожидается дружеский визит.",
        "Отдых. Ура!",
        "Все получится.",
        "Желания сбудутся.",
        "Ожидает приятный сон.",
        "Ждите награду.",
        "Все успеете.",
        "Мечты сбываются.",
        "Ошибки приведут к успеху.",
        "Произойдет что-то хорошее.",
        "Справитесь с проблемами.",
        "Печаль пройдет мимо.",
        "Недоразумение разрешится.",
        "Прорвемся.",
        "Беспокойство пройдет.",
        "Жизнь наладится.",
        "Кошмары не потревожат.",
        "Вас любят. Не сомневайтесь.",
        "Прогулка - хороший вариант.",
        "Ожидают хорошие знакомства.",
        //нейтральные
        "Слушайте интуицию.",
        "Верьте в себя.",
        "Прислушайтесь к себе.",
        "Придется выбирать.",
        "Каждый кризис несет новые возможности.",
        "Не сожалейте об ошибках.",
        "Не пытайтесь изменить человека.",
        "Исправьте ситуацию или поменяйте отношение к ней.",
        "Не поддавайтесь влиянию.",
        "Выход там же, где и вход.",
        "Бумеранг никто не отменял.",
        "Лучшее всегда является врагом хорошего.",
        "Думайте о главном.",
        "Не забывайте о мелочах.",
        "Не отказывайтесь от предложения.",
        "Ошибки - это нормально.",
        "Верьте в лучшее.",
        "Не отталкивайте людей.",
        "Не бойтесь ошибаться.",
        "Не бойтесь неумения.",
        "Сначала думайте, потом действуйте.",
        //негативные
        "Узнаете неприятные слухи.",
        "Проблемы на пороге.",
        "Уделите внимание здоровью.",
        "Ошибки догоняют.",
        "Опоздаете на важное мероприятие.",
        "Результаты придется ждать долго.",
        "Приснится кошмар.",
        "Потеряете друзей.",
        "Ждет ссора.",
        "Будете в тупике.",
        "Ожидается что-то плохое.",
        "Придется уступить в споре.",
        "Ожидаются эмоциональные проблемы.",
        "Не поддавайтесь манипуляции.",
        "Увидите неискренность в знакомом." ,
        "Не доверяйте другим.",
        "Не поддавайтесь уговорам.",
        "Ожидает череда неудач.",
        "Высокая вероятность заболеть.",
        "Последствия будут плачевными.",
        "Эмоции победят.",
        "Ожидается большая трата денег.",
        "Планы будут разрушены.",
        "Ожидается проигрыш.",
        "Будьте аккуратней."
    }

    public void Start() {
        CrackedCookie.SetActive(false);
        InfoField.GetComponent<TextMeshPro>().text = "Нажимайте на печеньку, пока она не откроется";
    }

    public void FixedUpdate() {
        if (!IsCracked) {
            CookieShaking();
        } else {
            ++FramesPassed;
            if (FramesPassed > 50) {
                if (Input.touchCount > 0) {
                    FramesPassed = 0;
                    IsCracked = false;
                    FullCookie.SetActive(true);
                    CrackedCookie.SetActive(false);
                    InfoField.GetComponent<TextMeshPro>().text = "Нажимайте на печеньку, пока она не откроется";
                }
            }
        }
    }

    private void CookieShaking() {
        var Speed = 50.0f;
        var Amount = 0.2f;

        if (Input.touchCount > 0) {
            FullCookie.transform.position = new Vector3(FullCookie.transform.position.x, Mathf.Sin(Time.time * Speed) * Amount, 0);
            PassedTime += Time.deltaTime;
            if (PassedTime >= 3) {
                IsCracked = true;
                PassedTime = 0;
                FullCookie.SetActive(false);
                ShowPrediction();
            }
        } else {
            FullCookie.transform.position = new Vector3(0, 0, 0);
        }
    }

    private void ShowPrediction() {
        InfoField.GetComponent<TextMeshPro>().text = "Нажмите, чтобы получить еще одно предсказание";
        CrackedCookie.SetActive(true);

        var Rand = new Random();
        TextField.GetComponent<TextMeshPro>().text = Predictions[Rand.Next(0, Predictions.Count - 1)];
    }
}
