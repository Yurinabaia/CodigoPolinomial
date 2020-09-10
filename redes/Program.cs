using System;
using System.Collections.Generic;

namespace redes
{
    class Program
    {
        static void Main(string[] args)
        {
            int posiChave = 0, posVetorByte = 0, tamanhoChave = 0;
            Console.WriteLine("Digite a chave");
            Int64 numchave = Int64.Parse(Console.ReadLine());
            char[] ats;
            ats = numchave.ToString().ToCharArray();

            Console.WriteLine("Digite os bytes de dados");
            Int64 valor = Int64.Parse(Console.ReadLine());
            char[] arr;
            arr = valor.ToString().ToCharArray();

            int[] Chave = new int[numchave.ToString().Length];
            int[] vetorbyte = new int[valor.ToString().Length];


            tamanhoChave = numchave.ToString().Length;
            List<byte> listafinal = new List<byte>();
            List<byte> listaAuxiliar = new List<byte>();

            for (int i = 0; i < valor.ToString().Length; i++)
            {
                vetorbyte[i] = int.Parse(arr[i].ToString());
            }
            for (int i = 0; i < numchave.ToString().Length; i++)
            {
                Chave[i] = int.Parse(ats[i].ToString());
            }

            while (true)
            {


                if (posiChave == tamanhoChave)
                {
                    int qtdzeros = ListaZeros(ref listafinal);
                    while (qtdzeros != 0)
                    {
                        if (posVetorByte >= valor.ToString().Length)
                            break;
                        byte a = byte.Parse(vetorbyte[posVetorByte].ToString());
                        listafinal.Add(a);
                        qtdzeros--;
                        posVetorByte++;
                    }
                    ClonarLista(listafinal, ref listaAuxiliar);
                    listafinal.Clear();
                    posiChave = 0;
                }
                else if (posVetorByte < tamanhoChave)
                {
                    byte a = byte.Parse(vetorbyte[posVetorByte].ToString());
                    byte b = byte.Parse(Chave[posiChave].ToString());
                    listafinal.Add(converXor(a, b));
                    posiChave++;
                    posVetorByte++;
                }
                else
                {
                    byte a = byte.Parse(listaAuxiliar[posiChave].ToString());
                    byte b = byte.Parse(Chave[posiChave].ToString());
                    listafinal.Add(converXor(a, b));
                    posiChave++;
                }
                if (posVetorByte >= valor.ToString().Length)
                    break;


            }
            while (true)
            {
                if (listaAuxiliar.Count != tamanhoChave)
                {
                    listaAuxiliar.Insert(0, 0);
                }
                else
                    break;
            }

            Console.WriteLine("\n valor gerador é");
            foreach (var item in listaAuxiliar)
            {
                Console.Write(item.ToString());
            }

            Console.WriteLine("\n\n\nCriador NABAIA ");
            Console.WriteLine("https://github.com/Yurinabaia");

        }
        static byte converXor(byte numero1, byte numero2)
        {
            Boolean xor1, xor2, finalxor;
            if (numero1 == 1)
                xor1 = true;
            else
                xor1 = false;

            if (numero2 == 1)
                xor2 = true;
            else
                xor2 = false;

            finalxor = xor1 ^ xor2;
            return conversorByte(finalxor);

        }
        static byte conversorByte(bool a)
        {
            byte valorFinal = 0;
            if (a)
                valorFinal = 1;
            else
                valorFinal = 0;
            return valorFinal;
        }
        static int ListaZeros(ref List<byte> asd)
        {
            int contador = 0;
            int entrou = 0;
            while (true)
            {
                if (asd[contador] == 0)
                {
                    asd.RemoveAt(contador);
                    entrou++;
                }
                else
                    break;

            }
            return entrou;
        }
        static void ClonarLista(List<byte> lista1, ref List<Byte> lista2)
        {
            lista2.Clear();
            foreach (var item in lista1)
            {
                lista2.Add(item);
            }
            foreach (var item in lista2)
            {
                Console.Write(item.ToString());
            }
            Console.WriteLine("\n");
        }
       
    }
}
