using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    int pontos, teclaAtual;
    float relogio;
    KeyCode[] teclas;
    private void Start()
    {
        GerarSetas();
    }
    private void Update()
    {
        KeyCode[] arrowKeys = { KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.RightArrow };
        // Loop para checar se uma das teclas de seta foi pressionada
        foreach (KeyCode key in arrowKeys)
        {
            if (Input.GetKeyDown(key))
            {
                ChecarTecla(key);
                break; // Sai do loop após detectar uma tecla pressionada
            }
        }
        ContagemRegressiva();
    }
    void ContagemRegressiva()
    {
        relogio -= Time.deltaTime;
        UIManager.instance.AtualizarTextos(pontos, relogio);
        if (relogio <= 0)
        {
            pontos -= teclas.Length - teclaAtual;
            GerarSetas();
        }
    }
    void GerarSetas()
    {
        teclaAtual = 0;
        teclas = new KeyCode[Random.Range(5, 15)];
        for (int i = 0; i < teclas.Length; i++)
        {
            teclas[i] = (KeyCode)Random.Range(273, 276); // Gera uma tecla aleatória entre Down, Left, Up, Right
        }
        relogio = teclas.Length / 2;
        UIManager.instance.AtualizarSetas(teclas);
    }
    void ChecarTecla(KeyCode teclaPressionada)
    {
        if (teclaPressionada == teclas[teclaAtual])
        {
            pontos++;
            UIManager.instance.AtualizarSeta(teclaAtual, true);
        }
        else
        {
            pontos--;
            relogio--;
            UIManager.instance.AtualizarSeta(teclaAtual, false);
        }
        UIManager.instance.AtualizarTextos(pontos, relogio);
        teclaAtual++;
        if (teclaAtual == teclas.Length)
        {
            GerarSetas();
        }
    }
}




