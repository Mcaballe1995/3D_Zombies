using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour
{
    public static int numVidas = 10;
    public static int numBalas = 30;
    private static int maxNumBalas = 30;
    public static int hp_min = 1000;
    public static int hp_max;

    //recarga balas

    private static int recargaBalas = 5;
    private static int recargaVida = 2;


    // Start is called before the first frame update
   

    public static int Get_hpMin()
    {
        return hp_min;
    }

    public static void Set_hpMin(int hpmin)
    {
       
        hp_min -= hpmin;
    }

    public static void Set_vidaInicial(int hpmin)
    {
        hp_min = hpmin;
    }

    public static int Get_hpMax()
    {
        return hp_max;
    }

    public static void Set_hpMax(int hpmax)
    {
        Debug.Log("vida");
        hp_max = hpmax;
    }

    public static int GetNumBalas()
    {
        return numBalas;
    }

    public static void SetNumBalas(int nB)
    {
        numBalas = nB;
    }

    public static int GetMaxNumBalas()
    {
        return maxNumBalas;
    }

    public static void SetMaxNumBalas(int mB)
    {
        maxNumBalas = mB;
    }

    public static int GetRecargaBalas()
    {
        return recargaBalas;
    }

    public static void SetRecargaBalas(int rB)
    {
        recargaBalas = rB;
    }

    public static int GetRecargaVida()
    {
        return recargaVida;
    }

    public static void SetRecargaVida(int rV)
    {
        recargaVida = rV;
    }
}
