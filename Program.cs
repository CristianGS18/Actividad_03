using System;
using System.Collections.Generic; 
using System.IO;

/* Alumnos:
  
 * Cristian Gonzalez Santos
 * Octavio de Jesus Paniagua Vargas 
 
 */

namespace Actividad_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Arreglo dinamico
            List<float> arreglo = new List<float>();

            int opcion;

            do
            {
                //Menú de opciones
                Console.WriteLine("Menu:\n");
                Console.WriteLine("-Ingresar los numeros    [ 1 ]");
                Console.WriteLine("--Mostrar los numeros    [ 2 ]");
                Console.WriteLine("--Ordenar los numeros    [ 3 ]");
                Console.WriteLine("--Guardar los numeros    [ 4 ]");
                Console.WriteLine("--Salir                  [ 0 ]");
                Console.Write  ("\n--Ingrese su opcion      : ");
                opcion = int.Parse(Console.ReadLine());

                //Estrcutura de selección
                switch (opcion)
                {
                    case 1: //Ingresar Numeros al Arreglo
                        arreglo.Clear();

                        int tamaño;

                        Console.WriteLine("\n[Ingresar los numeros]");
                        Console.Write("¿Cantidad de numeros? ");

                        tamaño = int.Parse(Console.ReadLine());
                        Console.WriteLine("");

                        for (int i = 0; i < tamaño; i++)
                        {
                            float numero;
                            Console.Write("[ " + (i + 1) + " de " + tamaño + " ]: ");
                            numero = float.Parse(Console.ReadLine());
                            arreglo.Add(numero);
                        }

                        Console.WriteLine("");
                        break;

                    case 2:// Mostrar Numeros
                        Console.WriteLine("[Mostrar los numeros]\n");

                        ArchivoAccion("leer", arreglo);//Metodo para leer el archivo

                        Console.Write("");
                        break;

                    case 3://Ordenar el Arreglo
                        int sub;
                        do {
                            Console.WriteLine("[Ordenar los numeros]:");
                            Console.WriteLine("Ordenar del mayor al menor [ 1 ]");
                            Console.WriteLine("Ordenar del menor al mayor [ 2 ]");
                            Console.Write  ("\nElija el orden             : ");
                            sub = int.Parse(Console.ReadLine());
                            Console.WriteLine("");

                            //Metodo Burbuja
                            if (sub == 1)//Mayor a menor
                            {
                                for (int i = arreglo.Count - 1; i >= 0; i--)
                                {
                                    for (int j = 0; j < i; j++)
                                    {
                                        if (arreglo[j] < arreglo[j + 1])
                                        {
                                            float aux = arreglo[j];
                                            arreglo[j] = arreglo[j + 1];
                                            arreglo[j + 1] = aux;
                                        }
                                    }
                                }
                            }
                            else if (sub == 2)//Menor a Mayor
                            {
                                for (int i = arreglo.Count - 1; i >= 0; i--)
                                {
                                    for (int j = 0; j < i; j++)
                                    {
                                        if (arreglo[j] > arreglo[j + 1])
                                        {
                                            float aux = arreglo[j];
                                            arreglo[j] = arreglo[j + 1];
                                            arreglo[j + 1] = aux;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Orden no valido\n");
                            }

                        } while (sub != 1 && sub != 2);
                        
                        //Mostrar el resultado
                        for (int i = 0; i < arreglo.Count; i++)
                        {
                            Console.WriteLine("[ " + (i + 1) + " ]: " + arreglo[i]);
                        }

                        Console.WriteLine("");
                        break;

                    case 4://Guardar el Arreglo en el Archivo
                        Console.Write("[Guardar los numeros] ");

                        ArchivoAccion("escribir",arreglo);//Metodo para escribir en el archivo

                        Console.WriteLine("Se han guardado sus numeros\n");
                        break;

                    case 0://Finaliza el programa
                        Console.WriteLine("[Salir]");
                        break;

                    default:
                        Console.WriteLine("Opcion invalida\n");
                        break;
                }

            } while (opcion != 0);
                
        }

        static void ArchivoAccion(string accion, List<float> arregloA) {
            

            if (accion == "leer") //Leer archivo
            {
                //Abre el archivo de texto
                Stream Archivo = new FileStream("Archivo.txt", FileMode.OpenOrCreate);
                //Lee el archivo de texto
                StreamReader Leer = new StreamReader(Archivo);
                //Escribe el contenido del archivo de texto
                Console.WriteLine(Leer.ReadToEnd());             
                //Cierra el archivo de texto
                Leer.Close();
                Archivo.Close();
            }
            else if (accion == "escribir") //Escribir archivo
            {
                //Crea y sobeescribe el archivo de texto
                Stream CrearNuevo = new FileStream("Archivo.txt", FileMode.Create);
                CrearNuevo.Close();
                //Abre el archivo de texto
                Stream Archivo = new FileStream("Archivo.txt", FileMode.Open);
                //Escribe en el archivo de texto
                StreamWriter Escribir = new StreamWriter(Archivo);
                //Copia el arreglo en el archivo de texto
                for (int i = 0; i < arregloA.Count; i++)
                {
                    Escribir.WriteLine(arregloA[i]);
                }
                //Cierra el archivo de texto
                Escribir.Close();
                Archivo.Close();
            }

        }
    }
    
}
