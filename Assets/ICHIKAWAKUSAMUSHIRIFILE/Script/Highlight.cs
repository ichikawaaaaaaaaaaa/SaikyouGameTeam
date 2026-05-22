using UnityEngine;

public class Highlight : MonoBehaviour
{
    public Player player;

    void Update()
    {
        Vector3 mouseWorld =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mouseWorld.z = 0;

        Vector2Int gridPos =
            SpawnManager.instance.WorldToGrid(mouseWorld);

        Vector3 worldPos =
            SpawnManager.instance.GridToWorld(
                gridPos.x,
                gridPos.y
            );

        transform.position = worldPos;

        transform.localScale = new Vector3(
            player.harvestSizeX,
            player.harvestSizeY,
            1
        );
    }
}