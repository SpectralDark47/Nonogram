using UnityEngine;

public class Tile : MonoBehaviour
{
    public int x, y;  // Grid position
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log($"Tile clicked: X={x}, Y={y}");
        HighlightTile();
    }

    public void HighlightTile()
    {
        sr.color = Color.black; // Change tile color when clicked
    }
}
