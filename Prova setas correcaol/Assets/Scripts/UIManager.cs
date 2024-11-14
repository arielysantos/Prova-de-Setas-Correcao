using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] Sprite[] sprites;
    [SerializeField] Image[] imagens;
    [SerializeField] TextMeshProUGUI textoDePontuacao;
    [SerializeField] TextMeshProUGUI textoDoRelogio;
    private void Awake()
    {
        instance = this;
    }
    public void AtualizarSetas(KeyCode[] setas)
    {
        // Laço de repetição para atualizar todas as imagens de setas
        for (int i = 0; i < imagens.Length; i++)
        {
            // Se não houver mais setas no array, define como o sprite padrão
            if (i >= setas.Length)
            {
                imagens[i].sprite = sprites[0];
            }
            else
            {
                // Usando um switch para determinar o sprite baseado no valor de cada seta
                switch (setas[i])
                {
                    case KeyCode.DownArrow:
                        imagens[i].sprite = sprites[1];
                        break;
                    case KeyCode.UpArrow:
                        imagens[i].sprite = sprites[2];
                        break;
                    case KeyCode.LeftArrow:
                        imagens[i].sprite = sprites[3];
                        break;
                    case KeyCode.RightArrow:
                        imagens[i].sprite = sprites[4];
                        break;
                }
            }
            imagens[i].color = Color.white;
        }
    }
    public void AtualizarSeta(int setaSelecionada, bool acertou)
    {
        // Define a cor da seta usando operador ternário
        imagens[setaSelecionada].color = acertou ? Color.green : Color.red;
    }
    public void AtualizarTextos(int pontuacao, float relogio)
    {
        // Atualiza o texto da pontuação
        textoDePontuacao.text = pontuacao.ToString();
        // Formata o relógio para mostrar uma casa decimal e evita valores negativos
        textoDoRelogio.text = Mathf.Max(0, relogio).ToString("F1");
    }
}