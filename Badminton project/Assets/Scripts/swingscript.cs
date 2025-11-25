
using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwingerAction : MonoBehaviour, IPointerUpHandler
{
    public Joystick joystick; // 기존 Joystick.cs 연결

    public event Action<int> OndirectionSelected;

    void Update()
    {
        // 테스트용: 드래그 중 방향 확인
        if (joystick.Direction().magnitude > 0.1f)
        {
            Debug.Log("현재 방향: " + joystick.Direction());
        }
    }

    public void OnSwingerReleased()
    {
        Vector2 dir = joystick.Direction();

        if (dir.magnitude < 0.1f)
        {
            Debug.Log("입력 없음");
            return;
        }

        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        if (angle < 0) angle += 360f;

        int direction = Mathf.FloorToInt(angle / 60f) + 1; // 1~6 범위

        Debug.Log("선택된 조각: " + direction);
        OndirectionSelected?.Invoke(direction);
        // direction 값에 따라 신호 보냄
        switch (direction)
        {
            case 1: Debug.Log("행동 1 실행!"); break;
            case 2: Debug.Log("행동 2 실행!"); break;
            case 3: Debug.Log("행동 3 실행!"); break;
            case 4: Debug.Log("행동 4 실행!"); break;
            case 5: Debug.Log("행동 5 실행!"); break;
            case 6: Debug.Log("행동 6 실행!"); break;
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        OnSwingerReleased();
    }
}
