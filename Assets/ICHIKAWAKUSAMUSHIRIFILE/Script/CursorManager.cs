using UnityEngine;
using System.Collections;

public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance;

    public Texture2D weaponCursor;
    public Texture2D hitCursor;

    private Coroutine resetRoutine;

    void Awake()
    {
        Instance = this;
    }

    // 武器カーソル（通常状態）
    public void SetWeaponCursor(Texture2D tex)
    {
        Apply(tex);
    }

    // 草を刈ったときなどの一時カーソル
    public void PlayHitCursor(float duration)
    {
        if (resetRoutine != null)
            StopCoroutine(resetRoutine);

        resetRoutine = StartCoroutine(HitRoutine(duration));
    }

    IEnumerator HitRoutine(float duration)
    {
        Apply(hitCursor);

        yield return new WaitForSeconds(duration);

        Apply(weaponCursor);
    }

    void Apply(Texture2D tex)
    {
        if (tex == null) return;

        Vector2 hotSpot = new Vector2(tex.width / 2, tex.height / 2);
        Cursor.SetCursor(tex, hotSpot, CursorMode.Auto);
    }
}