using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class movimentotextura : MonoBehaviour
{
    [SerializeField] private float speedy;
    [SerializeField] private float speedx;
    private MeshRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rend.material.mainTextureOffset = new Vector2(speedx * Time.timeSinceLevelLoad, speedy * Time.timeSinceLevelLoad);
    }
}
