using IPC2S1.Modelos;
using IPC2S1.Servicios;
using IPC2S1.Utilidades;

namespace IPC2S1.Interfaz
{
    public class Menu
    {
        private ServicioBiblioteca biblioteca = new();

        public void Mostrar()
        {
            int op;

            do
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("   SISTEMA DE BIBLIOTECA IPC2");
                Console.WriteLine("=================================");
                Console.WriteLine($"Total: {biblioteca.ContarTodos()}  |  Disponibles: {biblioteca.ContarDisponibles()}  |  Prestados: {biblioteca.ContarPrestados()}");
                Console.WriteLine("\nSeleccione una opción:");
                Console.WriteLine("1. Registrar Libro Físico");
                Console.WriteLine("2. Registrar Libro Digital");
                Console.WriteLine("3. Mostrar Todos");
                Console.WriteLine("4. Buscar por Título");
                Console.WriteLine("5. Consultar por Código");
                Console.WriteLine("6. Mostrar Disponibles");
                Console.WriteLine("7. Mostrar Prestados");
                Console.WriteLine("8. Prestar");
                Console.WriteLine("9. Devolver");
                Console.WriteLine("10. Salir");

                op = EntradaHelper.LeerEntero("Seleccione: ", 1, 10);

                switch (op)
                {
                    case 1: RegistrarFisico(); break;
                    case 2: RegistrarDigital(); break;
                    case 3: biblioteca.MostrarTodos(); break;
                    case 4: BuscarTitulo(); break;
                    case 5: ConsultarCodigo(); break;
                    case 6: MostrarDisponibles(); break;
                    case 7: MostrarPrestados(); break;
                    case 8: Prestar(); break;
                    case 9: Devolver(); break;
                }
                if (op != 10)
                {
                    Console.WriteLine("\nPresione ENTER para continuar...");
                    Console.ReadLine();
                }

            } while (op != 10);
        }

        private void RegistrarFisico()
        {
            string titulo = EntradaHelper.LeerTexto("Título: ");
            string autor = EntradaHelper.LeerTexto("Autor: ");
            int ejemplar = EntradaHelper.LeerEntero("Ejemplar (>=1): ", 1);

            var libro = new LibroFisico(titulo, autor, biblioteca.GenerarCodigo(), ejemplar);
            biblioteca.Agregar(libro);

            Console.WriteLine($"Libro físico registrado con código: {libro.Codigo}");
        }

        private void RegistrarDigital()
        {
            string titulo = EntradaHelper.LeerTexto("Título: ");
            string autor = EntradaHelper.LeerTexto("Autor: ");
            double tam = EntradaHelper.LeerDouble("Tamaño MB (>0): ", 0.01);

            var libro = new LibroDigital(titulo, autor, biblioteca.GenerarCodigo(), tam);
            biblioteca.Agregar(libro);

            Console.WriteLine($"Libro digital registrado con código: {libro.Codigo}");
        }

private void BuscarTitulo()
{
    string titulo = EntradaHelper.LeerTexto("Buscar: ");
    var lista = biblioteca.BuscarTitulo(titulo);

    if (lista.Count == 0)
    {
        Console.WriteLine("No se encontraron materiales con ese título.");
        return;
    }

    foreach (var m in lista)
    {
        Console.WriteLine("\n----------------");
        m.MostrarInfo();
    }
}

private void Prestar()
{
    string codigo = EntradaHelper.LeerTexto("Código: ");
    var m = biblioteca.BuscarCodigo(codigo);

    if (m == null)
    {
        Console.WriteLine("No existe un material con ese código.");
        return;
    }

    m.Prestar();
}
private void Devolver()
{
    string codigo = EntradaHelper.LeerTexto("Código: ");
    var m = biblioteca.BuscarCodigo(codigo);

    if (m == null)
    {
        Console.WriteLine("No existe un material con ese código.");
        return;
    }

    m.Devolver();
}

private void ConsultarCodigo()
{
    string codigo = EntradaHelper.LeerTexto("Código: ");
    var m = biblioteca.BuscarCodigo(codigo);

    if (m == null)
    {
        Console.WriteLine("No existe un material con ese código.");
        return;
    }

    Console.WriteLine("\n----------------");
    m.MostrarInfo();
}

private void MostrarDisponibles()
{
    var lista = biblioteca.ObtenerDisponibles();

    if (lista.Count == 0)
    {
        Console.WriteLine("No hay materiales disponibles.");
        return;
    }

    foreach (var m in lista)
    {
        Console.WriteLine("\n----------------");
        m.MostrarInfo();
    }
}

private void MostrarPrestados()
{
    var lista = biblioteca.ObtenerPrestados();

    if (lista.Count == 0)
    {
        Console.WriteLine("No hay materiales prestados.");
        return;
    }

    foreach (var m in lista)
    {
        Console.WriteLine("\n----------------");
        m.MostrarInfo();
    }
}
    }
}
