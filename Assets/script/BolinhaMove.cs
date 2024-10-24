using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Callbacks;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class BolinhaMove : MonoBehaviour
{
    private float moveH;
    private float moveV;
    private Rigidbody rb;
    public int contcoin;
    [SerializeField] private float velocidade;
    [SerializeField] private float forcaPulo;
    [SerializeField] private int countcoin = 0;
    public GameObject coin;
    public TextMeshProUGUI coinColected;
    private bool Jumping;
    private bool Vida;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //movimento da bolinha
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");
        transform.position += new Vector3(moveH * velocidade * Time.deltaTime,0, moveV * velocidade * Time.deltaTime);

        coinColected.text = countcoin.ToString();

        //pulo da bolinha
        if (Input.GetKeyDown(KeyCode.Space) && Jumping == false)
        {
            rb.AddForce(transform.up * forcaPulo, ForceMode.Impulse);
            Jumping = true;
        }
    }

//Morte da bolinha
    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("agua"))
        {
            Destroy(this.gameObject);
             SceneManager.LoadScene(3);
        }
        if(other.gameObject.CompareTag("chao"))
        {
            Jumping = false;
        }

    }
//Coletar a moedinhas
     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            countcoin ++ ;
        }

        if  (other.gameObject.CompareTag("portal") && countcoin == 10)
        {
            SceneManager.LoadScene(2);
        }
        
        if (other.gameObject.CompareTag("portal2") && countcoin == 13)
        {
            SceneManager.LoadScene(4);
        }
    }
}