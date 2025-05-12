using UnityEditor;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int [,] grid;
    public float followSpeed = 3.0f;
    public Sprite sprite; // Assign a sprite in the inspector
    int vertical, horizontal, columns, rows;
    private static Vector2 cameraPosition;
    void Start()
    {
        vertical = (int)Camera.main.orthographicSize;
        horizontal = vertical * (Screen.width / Screen.height);
        columns = horizontal * 2;
        rows = vertical * 2;
        grid = new int[columns, rows];
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                grid[i, j] = 0;
                SpawnTile(i, j, grid[i, j]);
            }
        }
    }

    private void SpawnTile(int x, int y, int value){
        GameObject go = new GameObject("X" + x + "Y" + y);
        go.AddComponent<BoxCollider2D>();
        go.transform.position = new Vector3 (x - (horizontal - 0.5f), y - (vertical - 0.5f), 0);
        var s = go.AddComponent<SpriteRenderer>();
        s.sprite = sprite;
        var tile = go.AddComponent<Tile>();
        tile.x = x;
        tile.y = y;
    }

    private void OnMouseUp(){
        cameraPosition = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
        Vector2 mouseWP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(cameraPosition, Input.mousePosition);

    }
}
