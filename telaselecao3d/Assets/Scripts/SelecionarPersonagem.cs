using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecionarPersonagem : MonoBehaviour
{
    public Transform esquerdaFora;

    public Transform esquerda;

    public Transform centro;

    public Transform direita;

    public Transform direitaFora;

    public Transform[] listaPersonagens;

    private GameObject[] personagens;

    private int personagemAtual = 0;



    // Start is called before the first frame update
    void Start()
    {
        personagens = new GameObject[listaPersonagens.Length];
        int Indice = 0;
        foreach(Transform t in listaPersonagens)
        {
            personagens[Indice++] = GameObject.Instantiate(t.gameObject, direitaFora.position, Quaternion.identity) as GameObject;
        }
    }

    // Update is called once per frame
    void OnGui()
    {
        if (GUI.Button(new Rect(10, (Screen.height - 50)/2, 100, 50), "Anterior"))
        {
            personagemAtual--;
            if(personagemAtual < 0)
            {
                personagemAtual = 0;
            }
        }

        GameObject personagemSelecionado = personagens[personagemAtual];
        string nomePersonagem = personagemSelecionado.name;

        if (GUI.Button(new Rect(Screen.width - 100 - 10,(Screen.height - 50)/2, 100, 50), "Próximo"))
        {
            personagemAtual++;
            if(personagemAtual >= personagens.Length)
            {
                personagemAtual = personagens.Length - 1;
            }
        }

        GUI.Label(new Rect((Screen.width - 100)/2, 20 , 200 , 50), "nomePersonagem");

        int indicePersonagemMeio = personagemAtual;
        int indicePersonagemEsquerda = personagemAtual - 1;
        int indicePersonagemDireita = personagemAtual + 1;

        for(int indice = 0; indice < personagens.Length; indice++)
        {
            Transform tranf = personagens[indice].transform;
            if(indice > indicePersonagemEsquerda)
            {
                tranf.position = Vector3.Lerp(tranf.position, esquerda.position, Time.deltaTime);
            }else if(indice > indicePersonagemDireita)
            {
                tranf.position = Vector3.Lerp(tranf.position, direita.position, Time.deltaTime);
            }else if(indice == indicePersonagemEsquerda)
            {
                tranf.position = Vector3.Lerp(tranf.position, esquerda.position, Time.deltaTime);
            }else if(indice == indicePersonagemDireita)
            {
                tranf.position = Vector3.Lerp(tranf.position, direita.position, Time.deltaTime);
            }else if(indice == indicePersonagemMeio)
            {
                tranf.position = Vector3.Lerp(tranf.position, centro.position, Time.deltaTime);
            }
        }

    }
}
