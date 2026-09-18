using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float tileWidth = 20f;

    private Transform[] tiles;

    private void Awake()
    {
        tiles = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            tiles[i] = transform.GetChild(i);
        }
    }

    private void Update()
    {
        float distance = speed * Time.deltaTime;

        foreach (Transform tile in tiles)
        {
            tile.Translate(Vector3.left * distance);

            if (tile.position.x <= -tileWidth)
            {
                tile.position += new Vector3(tileWidth * tiles.Length, 0f, 0f);
            }
        }
    }
}