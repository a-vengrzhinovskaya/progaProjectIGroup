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
        //�������
        "����� - ���� ��������.",
        "����� ����� ����������.",
        "����� ����������� �������.",
        "������� ��, ��� �����.",
        "����� ������� �������.",
        "�������� �������������.",
        "�������� �����������.",
        "�������� �������� ����������.",
        "�������� ������.",
        "���� ����� ������.",
        "������ ��������� �����.",
        "��������� ��������� �����.",
        "�����. ���!",
        "��� ���������.",
        "������� ��������.",
        "������� �������� ���.",
        "����� �������.",
        "��� �������.",
        "����� ���������.",
        "������ �������� � ������.",
        "���������� ���-�� �������.",
        "���������� � ����������.",
        "������ ������� ����.",
        "������������� ����������.",
        "���������.",
        "������������ �������.",
        "����� ���������.",
        "������� �� ����������.",
        "��� �����. �� ������������.",
        "�������� - ������� �������.",
        "������� ������� ����������.",
        //�����������
        "�������� ��������.",
        "������ � ����.",
        "������������� � ����.",
        "�������� ��������.",
        "������ ������ ����� ����� �����������.",
        "�� ��������� �� �������.",
        "�� ��������� �������� ��������.",
        "��������� �������� ��� ��������� ��������� � ���.",
        "�� ������������ �������.",
        "����� ��� ��, ��� � ����.",
        "�������� ����� �� �������.",
        "������ ������ �������� ������ ��������.",
        "������� � �������.",
        "�� ��������� � �������.",
        "�� ������������� �� �����������.",
        "������ - ��� ���������.",
        "������ � ������.",
        "�� ������������ �����.",
        "�� ������� ���������.",
        "�� ������� ��������.",
        "������� �������, ����� ����������.",
        //����������
        "������� ���������� �����.",
        "�������� �� ������.",
        "������� �������� ��������.",
        "������ ��������.",
        "��������� �� ������ �����������.",
        "���������� �������� ����� �����.",
        "��������� ������.",
        "��������� ������.",
        "���� �����.",
        "������ � ������.",
        "��������� ���-�� ������.",
        "�������� �������� � �����.",
        "��������� ������������� ��������.",
        "�� ������������ �����������.",
        "������� ������������� � ��������." ,
        "�� ��������� ������.",
        "�� ������������ ��������.",
        "������� ������ ������.",
        "������� ����������� ��������.",
        "����������� ����� ����������.",
        "������ �������.",
        "��������� ������� ����� �����.",
        "����� ����� ���������.",
        "��������� ��������.",
        "������ ����������."
    }

    public void Start() {
        CrackedCookie.SetActive(false);
        InfoField.GetComponent<TextMeshPro>().text = "��������� �� ��������, ���� ��� �� ���������";
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
                    InfoField.GetComponent<TextMeshPro>().text = "��������� �� ��������, ���� ��� �� ���������";
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
        InfoField.GetComponent<TextMeshPro>().text = "�������, ����� �������� ��� ���� ������������";
        CrackedCookie.SetActive(true);

        var Rand = new Random();
        TextField.GetComponent<TextMeshPro>().text = Predictions[Rand.Next(0, Predictions.Count - 1)];
    }
}
