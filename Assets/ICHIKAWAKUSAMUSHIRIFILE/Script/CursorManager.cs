using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance;

    public string targetSceneName = "KUSAMUSHIRi";

    public Texture2D weaponCursor;
    public Texture2D hitCursor;

    private Coroutine resetRoutine;
    private bool isActiveScene;

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        CheckScene();
        Cursor.SetCursor(weaponCursor, Vector2.zero, CursorMode.Auto);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CheckScene();
    }

    void CheckScene()
    {
        isActiveScene = SceneManager.GetActiveScene().name == targetSceneName;

        if (!isActiveScene)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Apply(weaponCursor);
        }
    }

    public void SetWeaponCursor(Texture2D tex)
    {
        if (!isActiveScene) return;
        Apply(tex);
    }

    public void PlayHitCursor(float duration)
    {
        if (!isActiveScene) return;

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
        if (tex == null || !isActiveScene) return;

        Vector2 hotSpot = new Vector2(tex.width / 2, tex.height / 2);
        Cursor.SetCursor(tex, hotSpot, CursorMode.Auto);
    }
}