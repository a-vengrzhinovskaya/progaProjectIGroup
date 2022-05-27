using UnityEngine;
using TMPro;

public class Game : MonoBehaviour {
    public GameObject FullCookie;
    public GameObject CrackedCookie;
    public GameObject TextField;
    public GameObject InfoField;

    private float PassedTime = 0.0f;
    private bool IsCracked = false;
    private int FramesPassed = 0;

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

        //TODO: предсказания
        TextField.GetComponent<TextMeshPro>().text = "Аэаэаэаэаэа!!!!!!!!!!";
    }
}
