using System;
namespace DeepNeuralNetwork
{
  class DeepNetProgram
  {
    static void Main(string[] args)
    {
      Console.WriteLine("\nBegin Deep Neural Network input-output demo");

      Console.WriteLine("\nCreating a 3-4-5-2 neural network");
      int numInput = 3;
      int numHiddenA = 4;
      int numHiddenB = 5;
      int numOutput = 2;

      DeepNeuralNetwork dnn = new DeepNeuralNetwork(numInput, numHiddenA, numHiddenB, numOutput);

      double[] weights = new double[] { 0.01, 0.02, 0.03, 0.04, 0.05, 0.06, 0.07, 0.08, 0.09, 0.10,
        0.11, 0.12, 0.13, 0.14, 0.15, 0.16, 0.17, 0.18, 0.19, 0.20,
        0.21, 0.22, 0.23, 0.24, 0.25, 0.26, 0.27, 0.28, 0.29, 0.30,
        0.31, 0.32, 0.33, 0.34, 0.35, 0.36, 0.37, 0.38, 0.39, 0.40,
        0.41, 0.42, 0.43, 0.44, 0.45, 0.46, 0.47, 0.48, 0.49, 0.50,
        0.51, 0.52, 0.53 };

      dnn.SetWeights(weights);

      double[] xValues = new double[] { 1.0, 2.0, 3.0 };

      Console.WriteLine("\nDummy weights and bias values are:");
      ShowVector(weights, 10, 2, true);

      Console.WriteLine("\nDummy inputs are:");
      ShowVector(xValues, 3, 1, true);

      double[] yValues = dnn.ComputeOutputs(xValues);

      Console.WriteLine("\nComputed outputs are:");
      ShowVector(yValues, 2, 4, true);


      Console.WriteLine("\nEnd deep neural network input-output demo\n");
      Console.ReadLine();


    } // Main

    static public void ShowVector(double[] vector, int valsPerRow, int decimals, bool newLine)
    {
      for (int i = 0; i < vector.Length; ++i)
      {
        if (i % valsPerRow == 0) Console.WriteLine("");
        Console.Write(vector[i].ToString("F" + decimals).PadLeft(decimals + 4) + " ");
      }
      if (newLine == true) Console.WriteLine("");
    }


  } // Program


  public class DeepNeuralNetwork
  {
    private int numInput;
    private int numHiddenA;
    private int numHiddenB;
    private int numOutput;

    private double[] inputs;

    private double[][] iaWeights;
    private double[][] abWeights;
    private double[][] boWeights;

    private double[] aBiases;
    private double[] bBiases;
    private double[] oBiases;

    private double[] aOutputs;
    private double[] bOutputs;
    private double[] outputs;

    private static Random rnd;

    public DeepNeuralNetwork(int numInput, int numHiddenA, int numHiddenB, int numOutput)
    {
      this.numInput = numInput;
      this.numHiddenA = numHiddenA;
      this.numHiddenB = numHiddenB;
      this.numOutput = numOutput;

      inputs = new double[numInput];

      iaWeights = MakeMatrix(numInput, numHiddenA);
      abWeights = MakeMatrix(numHiddenA, numHiddenB);
      boWeights = MakeMatrix(numHiddenB, numOutput);

      aBiases = new double[numHiddenA];
      bBiases = new double[numHiddenB];
      oBiases = new double[numOutput];

      aOutputs = new double[numHiddenA];
      bOutputs = new double[numHiddenB];
      outputs = new double[numOutput];

      rnd = new Random(0);
      InitializeWeights();
    }

    private static double[][] MakeMatrix(int rows, int cols) // helper for ctor
    {
      double[][] result = new double[rows][];
      for (int r = 0; r < result.Length; ++r)
        result[r] = new double[cols];
      return result;
    }

    private void InitializeWeights()
    {
      int numWeights = (numInput * numHiddenA) + numHiddenA + (numHiddenA * numHiddenB) + numHiddenB + (numHiddenB * numOutput) + numOutput;
      double[] weights = new double[numWeights];
      double lo = -0.01;
      double hi = 0.01;
      for (int i = 0; i < weights.Length; ++i)
        weights[i] = (hi - lo) * rnd.NextDouble() + lo;
      this.SetWeights(weights);
    }

    public void SetWeights(double[] weights)
    {
      int numWeights = (numInput * numHiddenA) + numHiddenA + (numHiddenA * numHiddenB) + numHiddenB + (numHiddenB * numOutput) + numOutput;
      if (weights.Length != numWeights)
        throw new Exception("Bad weights length");

      int k = 0;

      for (int i = 0; i < numInput; ++i)
        for (int j = 0; j < numHiddenA; ++j)
          iaWeights[i][j] = weights[k++];

      for (int i = 0; i < numHiddenA; ++i)
        aBiases[i] = weights[k++];

      for (int i = 0; i < numHiddenA; ++i)
        for (int j = 0; j < numHiddenB; ++j)
          abWeights[i][j] = weights[k++];

      for (int i = 0; i < numHiddenB; ++i)
        bBiases[i] = weights[k++];

      for (int i = 0; i < numHiddenB; ++i)
        for (int j = 0; j < numOutput; ++j)
          boWeights[i][j] = weights[k++];

      for (int i = 0; i < numOutput; ++i)
        oBiases[i] = weights[k++];
    }

    public double[] ComputeOutputs(double[] xValues)
    {
      double[] aSums = new double[numHiddenA]; // hidden A nodes sums scratch array
      double[] bSums = new double[numHiddenB]; // hidden B nodes sums scratch array
      double[] oSums = new double[numOutput]; // output nodes sums

      for (int i = 0; i < xValues.Length; ++i) // copy x-values to inputs
        this.inputs[i] = xValues[i];

      for (int j = 0; j < numHiddenA; ++j)  // compute sum of (ia) weights * inputs
        for (int i = 0; i < numInput; ++i)
          aSums[j] += this.inputs[i] * this.iaWeights[i][j]; // note +=

      for (int i = 0; i < numHiddenA; ++i)  // add biases to a sums
        aSums[i] += this.aBiases[i];

      Console.WriteLine("\nInternal aSums:");
      DeepNetProgram.ShowVector(aSums, aSums.Length, 4, true);

      for (int i = 0; i < numHiddenA; ++i)   // apply activation
        this.aOutputs[i] = HyperTanFunction(aSums[i]); // hard-coded

      Console.WriteLine("\nInternal aOutputs:");
      DeepNetProgram.ShowVector(aOutputs, aOutputs.Length, 4, true);

      for (int j = 0; j < numHiddenB; ++j)  // compute sum of (ab) weights * a outputs = local inputs
        for (int i = 0; i < numHiddenA; ++i)
          bSums[j] += aOutputs[i] * this.abWeights[i][j]; // note +=

      for (int i = 0; i < numHiddenB; ++i)  // add biases to b sums
        bSums[i] += this.bBiases[i];

      Console.WriteLine("\nInternal bSums:");
      DeepNetProgram.ShowVector(bSums, bSums.Length, 4, true);

      for (int i = 0; i < numHiddenB; ++i)   // apply activation
        this.bOutputs[i] = HyperTanFunction(bSums[i]); // hard-coded

      Console.WriteLine("\nInternal bOutputs:");
      DeepNetProgram.ShowVector(bOutputs, bOutputs.Length, 4, true);

      for (int j = 0; j < numOutput; ++j)   // compute sum of (bo) weights * b outputs = local inputs
        for (int i = 0; i < numHiddenB; ++i)
          oSums[j] += bOutputs[i] * boWeights[i][j];

      for (int i = 0; i < numOutput; ++i)  // add biases to input-to-hidden sums
        oSums[i] += oBiases[i];

      Console.WriteLine("\nInternal oSums:");
      DeepNetProgram.ShowVector(oSums, oSums.Length, 4, true);

      double[] softOut = Softmax(oSums); // softmax activation does all outputs at once for efficiency
      Array.Copy(softOut, outputs, softOut.Length);

      double[] retResult = new double[numOutput]; // could define a GetOutputs method instead
      Array.Copy(this.outputs, retResult, retResult.Length);
      return retResult;
    }

    private static double HyperTanFunction(double x)
    {
      if (x < -20.0) return -1.0; // approximation is correct to 30 decimals
      else if (x > 20.0) return 1.0;
      else return Math.Tanh(x);
    }

    private static double[] Softmax(double[] oSums)
    {
      // determine max output sum
      // does all output nodes at once so scale doesn't have to be re-computed each time
      double max = oSums[0];
      for (int i = 0; i < oSums.Length; ++i)
        if (oSums[i] > max) max = oSums[i];

      // determine scaling factor -- sum of exp(each val - max)
      double scale = 0.0;
      for (int i = 0; i < oSums.Length; ++i)
        scale += Math.Exp(oSums[i] - max);

      double[] result = new double[oSums.Length];
      for (int i = 0; i < oSums.Length; ++i)
        result[i] = Math.Exp(oSums[i] - max) / scale;

      return result; // now scaled so that xi sum to 1.0
    }

  } // DeepNeuralNetwork

} // ns
