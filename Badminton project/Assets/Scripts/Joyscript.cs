using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [Header("UI References")]
    public RectTransform joystickBG;       // 조이스틱 배경
    public RectTransform joystickHandle;   // 조이스틱 핸들

    private Vector2 inputVector = Vector2.zero;
    private int pointerId = -1;            // 추적 중인 터치 ID

    // 터치 시작
    public void OnPointerDown(PointerEventData eventData)
    {
        if (pointerId == -1)  // 아직 아무 손가락도 추적하지 않을 때만
        {
            pointerId = eventData.pointerId;
            OnDrag(eventData); // 첫 입력 시 위치 갱신
        }
    }

    // 드래그 중 (조이스틱 이동)
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerId != pointerId) return;

        Vector2 pos;
        // Screen Space - Overlay에서는 camera가 필요 없으므로 null 전달
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickBG, eventData.position, null, out pos))
        {
            // BG 크기를 기준으로 -1 ~ 1 사이 값으로 정규화
            float x = pos.x / (joystickBG.sizeDelta.x / 2);
            float y = pos.y / (joystickBG.sizeDelta.y / 2);

            inputVector = new Vector2(x, y);
            if (inputVector.magnitude > 1.0f)
                inputVector = inputVector.normalized;

            // 핸들 위치 이동 (BG 안에서만 움직이도록 제한)
            joystickHandle.anchoredPosition = new Vector2(
                inputVector.x * (joystickBG.sizeDelta.x / 2),
                inputVector.y * (joystickBG.sizeDelta.y / 2));
        }
    }
// 터치 해제
    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerId == pointerId)
        {
            pointerId = -1;
            inputVector = Vector2.zero;
            joystickHandle.anchoredPosition = Vector2.zero;  // 중앙 복귀
        }
    }

    // 외부에서 가져다 쓸 값
    public float Horizontal() => inputVector.x;
    public float Vertical() => inputVector.y;
    public Vector2 Direction() => new Vector2(Horizontal(), Vertical());
}