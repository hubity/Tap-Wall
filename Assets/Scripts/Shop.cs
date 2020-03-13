using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class ButtonExtension
{
    public static void AddEventListener<T> (this Button button, T param, Action<T> OnClick)
    {
        button.onClick.AddListener(delegate ()
        {
            OnClick(param);
        });
    }
}

public class Shop : MonoBehaviour
{

    [Serializable]
    public struct Player
    {
        public string precotxt;
        public int precovalor;
        public Sprite icon;
        public int adquirido;
        public int selecionado;
        public GameObject bg;
    }

     int testeScore;
    public int numeroPlayerSelecionado;

    public Text valueCoinsTxt;
    public int valueCoins;

    [SerializeField] Player[] allPlayer;
    void Start()
    {
        testeScore = 100;

        valueCoins = PlayerPrefs.GetInt("coins");
        valueCoinsTxt.text = valueCoins.ToString();

        GameObject buttomTemplate = transform.GetChild(0).gameObject;
        GameObject g;


        int n = allPlayer.Length;

        for(int i = 0; i < n; i++)
        {
            g = Instantiate(buttomTemplate, transform);
            g.transform.GetChild(1).GetComponent<Text>().text = allPlayer[i].precotxt;
            g.transform.GetChild(2).GetComponent<Image>().sprite = allPlayer [i].icon;
            allPlayer[i].bg = g.transform.GetChild(0).gameObject;

            g.GetComponent<Button>().AddEventListener(i, ItemClicked);
            
        }
        Destroy(buttomTemplate);
    }

    void ItemClicked(int itemIndex)
    {
        numeroPlayerSelecionado = itemIndex;
        Debug.Log("preço " + allPlayer[itemIndex].precotxt);

        if(allPlayer[itemIndex].adquirido == 0)
        {
            if (allPlayer[itemIndex].precovalor < testeScore)
            {
                Debug.Log("player adquirido");
                allPlayer[itemIndex].adquirido = 1;
            }
        }
        else
        {
            if (allPlayer[itemIndex].adquirido == 1)
            {
                allPlayer[itemIndex].selecionado = 1;
                PlayerPrefs.SetInt("player", itemIndex);

                for (int i = 0; i < allPlayer.Length; i++)
                {
                    if(i != numeroPlayerSelecionado)
                    {
                        allPlayer[i].selecionado = 0;
                        allPlayer[i].bg.SetActive(false);
                        allPlayer[numeroPlayerSelecionado].bg.SetActive(true);
                        Debug.Log("=-=- Selecionado : " + numeroPlayerSelecionado);
                    }
                }
            }
        }
       
    }

    public void Voltar()
    {
        SceneManager.LoadScene("GamePlay");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
