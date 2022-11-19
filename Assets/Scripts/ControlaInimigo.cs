using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    public GameObject Jogador;
    public float Velocidade = 5;
    // Start is called before the first frame update
    void Start()
    {
        Jogador = GameObject.FindWithTag("Jogador");
        int geraTipo = Random.Range(1, 28);
        transform.GetChild(geraTipo).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        var direcao = Jogador.transform.position - transform.position;

        var distancia = Vector3.Distance(transform.position, Jogador.transform.position);

        var rotacao = Quaternion.LookRotation(direcao);
        GetComponent<Rigidbody>().MoveRotation(rotacao);

        if (distancia > 2.5)
        {
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direcao.normalized * Velocidade * Time.deltaTime);
            GetComponent<Animator>().SetBool("Atacando", false);
        }
        else
            GetComponent<Animator>().SetBool("Atacando", true);

    }

    void AtacaJogador()
    {
        Time.timeScale = 0;
        Jogador.GetComponent<ControleJogador>().GameOver.SetActive(true);
        Jogador.GetComponent<ControleJogador>().Vivo = false;
    }
}
