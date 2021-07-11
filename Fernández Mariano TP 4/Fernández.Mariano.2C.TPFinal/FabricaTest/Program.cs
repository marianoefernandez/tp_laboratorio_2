using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace FabricaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Mueble sillaMaderaRoble = new Madera(1,"silla de madera", 3, (float)2.6, 38, 32, 29, eColor.Rojo, eTipoDeMadera.Roble);
            Mueble sillaMaderaRoble2 = new Madera(2,"Silla de madera", 7, (float)2.6, 38, 32, 29, eColor.Rojo, eTipoDeMadera.Roble);
            Mueble mesaMaderaAbedul = new Madera(3,"Mesa de madera", 9, (float)8.7, 65, 51, 44, eColor.Negro, eTipoDeMadera.Abedul);
            Mueble escritorioMaderaPino = new Madera(4,"Escritorio de madera", 5, (float)6.9, 46, 40, 38, eColor.Sin, eTipoDeMadera.Pino);
            Mueble sillaMetalAluminio = new Metal(5,"Silla de aluminio", 1, (float)4.4, 41, 34, 25, eColor.Violeta, eTipoDeMetal.Aluminio);//Deberia setear el color en Sin
            Mueble mesaMetalAcero = new Metal(6,"Mesa de acero", 2 , (float)9.9, 66, 49, 41, eColor.Verde, eTipoDeMetal.Acero);
            Mueble mesaVidrio = new Vidrio(7,"Mesa de vidrio", 4 , (float)7.6, 61, 47, 43);

            Fabrica.AgregarMueble = sillaMaderaRoble;
            Fabrica.AgregarMueble = sillaMaderaRoble2;
            Console.WriteLine(Fabrica.RetornarInformacionTotal());
            Fabrica.AgregarMueble = mesaMaderaAbedul;
            Fabrica.AgregarMueble = escritorioMaderaPino;
            Fabrica.AgregarMueble = sillaMetalAluminio;
            Fabrica.AgregarMueble = mesaMetalAcero;
            Fabrica.AgregarMueble = mesaVidrio;
            
            Console.WriteLine(sillaMetalAluminio.Facturacion());
            Console.WriteLine(sillaMaderaRoble.Facturacion());
            Console.WriteLine(mesaVidrio.Facturacion());
            Console.WriteLine(Fabrica.RetornarInformacionTotal());

            Mueble mesaVidrio2 = new Vidrio();//Por defecto, no deberia dejar de agregar a la lista
            Mueble mesaMadera = new Madera();//Por defecto, no deberia dejar de agregar a la lista
            Mueble sillaMetal = new Metal();//Por defecto, no deberia dejar de agregar a la lista
            Fabrica.Muebles.Clear();//Limpiamos para probar los muebles invalidos
            Console.WriteLine(mesaVidrio2);
            Console.WriteLine(mesaMadera);
            Console.WriteLine(sillaMetal);
            Fabrica.AgregarMueble = mesaVidrio2;//NO SE AGREGA A LA LISTA
            Fabrica.AgregarMueble = mesaMadera;//NO SE AGREGA A LA LISTA
            Fabrica.AgregarMueble = sillaMetal;//NO SE AGREGA A LA LISTA
            Console.WriteLine(Fabrica.RetornarInformacionTotal());//No deberia retornar nada.
            Console.Read();


        }
    }
}
