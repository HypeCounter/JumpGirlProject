using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{


    [SerializeField] private Transform pontoA;
    [SerializeField] private Transform pontoB;
    [SerializeField] private float velocidade;
    private bool moverParaPontoA;
    private bool moverParaPontoB;
    public bool face = true;
    public Transform enemyT;
    private Animator anim;
   

    private void Awake()
    {
       
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        moverParaPontoA = true;
    }

    void Update()
    {
        
        if (moverParaPontoA == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, pontoA.position,
                                                                        velocidade * Time.deltaTime);
            if (transform.position.x == pontoA.position.x)
            {
                Flip();
                
                moverParaPontoA = false;
                moverParaPontoB = true;
            }

        }


        if (moverParaPontoB == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, pontoB.position,
                velocidade * Time.deltaTime);
            if (transform.position.x == pontoB.position.x)
            {
                Flip();
                
                moverParaPontoA = true;
                moverParaPontoB = false;
            }

        }

    }
    private void Flip() {
        face = !face;

        Vector3 escala = enemyT.localScale;
        escala.x *= -1;
        enemyT.localScale = escala;
    }
}