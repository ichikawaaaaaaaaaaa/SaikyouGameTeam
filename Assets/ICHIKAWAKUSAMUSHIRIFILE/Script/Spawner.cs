using UnityEngine;

public class Spawner : MonoBehaviour
{
    private bool decided = false;

    public void TrySpawn(float chance, GameObject prefab)
    {
        if (decided) return;
        decided = true;

        if (Random.value < chance)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}
