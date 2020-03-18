using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallUVController : MonoBehaviour
{
    public Material wallMat;
    public Vector2 direction;
    public float speed;

    private Vector2 neutral;
    private Vector2 currentOffset;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(1,0);
        speed = 0.1f;
        neutral = new Vector2(0,0);
        wallMat.SetTextureOffset("_MainTex", neutral);
        currentOffset = wallMat.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        currentOffset += direction * speed * Time.deltaTime;
        wallMat.SetTextureOffset("_MainTex", currentOffset);
    }
}
