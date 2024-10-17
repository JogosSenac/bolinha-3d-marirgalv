using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Callbacks;
using UnityEngine;

public class BolinhaMove : MonoBehaviour
{
    private float moveH;
    private float moveV;
    private Rigidbody rb;
    public int contcoin;
    [SerializeField] private float velocidade;
    [SerializeField] private float forcaPulo;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        contcoin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //movimento da bolinha
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");
        transform.position += new Vector3(moveH * velocidade * Time.deltaTime,0, moveV * velocidade * Time.deltaTime);

        //pulo da bolinha
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * forcaPulo, ForceMode.Impulse);
        }
    }

//Morte da bolinha
    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("agua"))
        {
            Destroy(this.gameObject);
        }

    }
//Coletar a moedinhas
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            contcoin +=1;
        }
    }
}