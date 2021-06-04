using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using UnityEngine;
using Random = System.Random;

public class Network
{

    
    float off = 0.01f;

    float distance1, distance2;

    [Range(-0.5f, 0.5f)]
    [SerializeField]
    float[] W1 = new float[35];
    [Range(-0.5f, 0.5f)]
    [SerializeField]
    float[] W2 = new float[10];

    [Range(-0.5f, 0.5f)]
    [SerializeField]
    float[] b1 = new float[5];
    [Range(-0.5f, 0.5f)]
    [SerializeField]
    float[] b2 = new float[2];

    float u, d;


    public Network()
    {
        //InitValues();
        //LoadValues();

    }

   /* public void LoadValues(ref Random rnd)
    {
        //Values data =  ValueContaier.value;
        float range = 0.000004f;
        


        for (int i = 0; i < W1.Length; i++)
        {
            W1[i] = data.W1[i] + Randomize(range, ref rnd);
        }
        for (int i = 0; i < W2.Length; i++)
        {
            W2[i] = data.W2[i] + Randomize(range, ref rnd);
        }
        for (int i = 0; i < b1.Length; i++)
        {
            b1[i] = data.b1[i] + Randomize(range, ref rnd);
        }
        for (int i = 0; i < b2.Length; i++)
        {
            b2[i] = data.b2[i] + Randomize(range, ref rnd);
       }
    }
    public void LoadValues()
    {
        //Values data = ValueContaier.value;

        for (int i = 0; i < W1.Length; i++)
        {
            W1[i] = data.W1[i];
        }
        for (int i = 0; i < W2.Length; i++)
        {
            W2[i] = data.W2[i];
        }
        for (int i = 0; i < b1.Length; i++)
        {
            b1[i] = data.b1[i];
        }
        for (int i = 0; i < b2.Length; i++)
        {
            b2[i] = data.b2[i];
        }
    }
    */
    public void InitValues(ref Random rnd)
    {
        for (int i = 0; i < W1.Length; i++)
        {
            W1[i] = (float)rnd.NextDouble() - 0.5f;
        }
        for (int i = 0; i < W2.Length; i++)
        {
            W2[i] = (float)rnd.NextDouble() -0.5f;
        }
        for (int i = 0; i < b1.Length; i++)
        {
            b1[i] = (float)rnd.NextDouble() - 0.5f;
        }
        for (int i = 0; i < b2.Length; i++)
        {
            b2[i] = (float)rnd.NextDouble() - 0.5f;
        }
    }

    private void CalulateValues(float distToUp, float distToCeil, float distFor, float distToPipe, float distForUp, float distForDown, float distToDown)
    {
        float a1 = ReLU(distToUp * W1[0] + distToCeil * W1[1] + distFor * W1[2] + distToPipe * W1[3] + distForUp * W1[4] + distForDown * W1[5] + distToDown * W1[6] +       b1[0]);
        float a2 = ReLU(distToUp * W1[7] + distToCeil * W1[8] + distFor * W1[9] + distToPipe * W1[10] + distForUp * W1[11] + distForDown * W1[12] + distToDown * W1[13] +     b1[1]);
        float a3 = ReLU(distToUp * W1[14] + distToCeil * W1[15] + distFor * W1[16] + distToPipe * W1[17] + distForUp * W1[18] + distForDown * W1[19] + distToDown * W1[20] + b1[2]);
        float a4 = ReLU(distToUp * W1[21] + distToCeil * W1[22] + distFor * W1[23] + distToPipe * W1[24] + distForUp * W1[25] + distForDown * W1[26] + distToDown * W1[27] + b1[3]);
        float a5 = ReLU(distToUp * W1[28] + distToCeil * W1[29] + distFor * W1[30] + distToPipe * W1[31] + distForUp * W1[32] + distForDown * W1[33] + distToDown * W1[34] + b1[4]);




        u = Sigmoid(a1 * W2[0] + a2 * W2[1] + a3 * W2[2] + a4 * W2[3] + a5 * W2[4] + b2[0]);
        d = Sigmoid(a1 * W2[5] + a2 * W2[6] + a3 * W2[7] + a4 * W2[8] + a5 * W2[9] + b2[1]);
    }
    public float GetValue(float distToUp, float distToCeil, float distFor, float distToPipe, float distForUp, float distForDown, float distToDown)
    {
        CalulateValues(distToUp, distToCeil, distFor, distToPipe, distForUp, distForDown,distToDown);
        // Debug.Log("U: ");Debug.Log(u);
        //Debug.Log("D: "); Debug.Log(d);

        return u > d  ? 1 : 0;
    }
    
    float Sigmoid(float x)
    {
        return 1 / (1 + Mathf.Exp(-x));
    }
    float ReLU(float x)
    {
        return x > 0 ? x : 0;
    }
    public void Save()
    {
        Values val = new Values(W1, W2, b1, b2);
        SaveSystem.SaveValues(val);
    }
    private float Randomize(float range, ref Random rnd)
    {
        float f = (1f / range)/2;
        return ((float)rnd.NextDouble()/f) - range;
    }
    public Values GetValues()
    {
        return new Values(W1, W2, b1, b2);
    }
}
[System.Serializable]
public class Values
{
    public float[] W1;
    public float[] W2;
    public float[] b1;
    public float[] b2;
    public Values(float[] _W1, float[] _W2, float[] _b1, float[] _b2)
    {
        W1 = _W1;
        W2 = _W2;
        b1 = _b1;
        b2 = _b2;
    }

}
