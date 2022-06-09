using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public GameObject originalTile;
    public GameObject player;

    public int currentZ = 6;


    // Start is called before the first frame update
    void Start()
    {
        for (int a = 0; a < 10; ++a)
        {
            this.genNewRow();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.currentZ - this.getPlayerZ() <= 50) {
            this.genNewRow();
        }

    }

    void genNewRow()
    {
        for (int a = -2; a <= 2; a += 2)
        {
            if (Random.Range(0, 3) == 0)
            {
                GameObject newObject = GameObject.Instantiate(originalTile);
                newObject.transform.position = new Vector3((float)a, 0, (float)currentZ);
                newObject.SetActive(true);
            }
        }
        this.currentZ += 2;

    }
    float getPlayerZ()
    {
        return player.transform.position.z;
    }
}
