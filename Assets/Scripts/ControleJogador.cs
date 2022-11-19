using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleJogador : MonoBehaviour
{
    public float Velocidade = 10;
    public GameObject GameOver;
    Vector3 direcao;
    public float horizontalSpeed = 1.0F;
    public bool Vivo = true;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        int geraTipo = Random.Range(1, 24);
        transform.GetChild(geraTipo).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(-eixoX, 0, -eixoZ);
    

        GetComponent<Animator>().SetBool("Movendo", direcao != Vector3.zero);

        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, h, 0);


        if(Vivo == false && Input.GetButtonDown("Fire1"))
            SceneManager.LoadScene("game");

    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direcao * Velocidade * Time.deltaTime));

        //Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Debug.DrawRay(raio.origin, raio.direction, Color.red);

        //RaycastHit impacto;

        //if(Physics.Raycast(raio, out impacto, 100))
        //{
        //    Vector3 posicaoMiraJogador = impacto.point - transform.position;

        //    Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);

        //    GetComponent<Rigidbody>().MoveRotation(novaRotacao);
        //}
    }
}
