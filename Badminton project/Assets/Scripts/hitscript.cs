using UnityEngine;

public class HitScript : MonoBehaviour
{
    public Animator swAnimator;      // 부모 Animator
    public string swswing;           // 켜고 싶은 애니메이션 이름
    private BoxCollider2D boxCol;    // BoxCollider2D 캐시
    private SpriteRenderer sprite;   // 시각적 표시용 SpriteRenderer 캐시

    void Awake()
    {
        boxCol = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        // 시작 시 비활성화
        if (boxCol != null) boxCol.enabled = false;
        if (sprite != null) sprite.enabled = false;
    }

    void Update()
    {
        AnimatorStateInfo state = swAnimator.GetCurrentAnimatorStateInfo(0);
        bool isSwinging = state.IsName(swswing);

        // 애니메이션 상태에 따라 콜라이더와 스프라이트 토글
        if (boxCol != null) boxCol.enabled = isSwinging;
        if (sprite != null) sprite.enabled = isSwinging;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("트리거에 들어옴: " + other.name);
    }
}

