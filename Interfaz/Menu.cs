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
                Console.WriteLine("\n===== BIBLIOTECA =====");
                Console.WriteLine("1. Registrar Libro Físico");
                Console.WriteLine("2. Registrar Libro Digital");
                Console.WriteLine("3. Mostrar Materiales");
                Console.WriteLine("4. Buscar por Título");
                Console.WriteLine("5. Prestar");
                Console.WriteLine("6. Devolver");
                Console.WriteLine("7. Salir");

                op = EntradaHelper.LeerEntero("Seleccione: ");

                switch (op)
                {
                    case 1: RegistrarFisico(); break;
                    case 2: RegistrarDigital(); break;
                    case 3: biblioteca.MostrarTodos(); break;
                    case 4: BuscarTitulo(); break;
                    case 5: Prestar(); break;
                    case 6: Devolver(); break;
                }

            } while (op != 7);
        }

        private void RegistrarFisico()
        {
            string titulo = EntradaHelper.LeerTexto("Título: ");
            string autor = EntradaHelper.LeerTexto("Autor: ");
            int ejemplar = EntradaHelper.LeerEntero("Ejemplar: ");

            var libro = new LibroFisico(titulo, autor, biblioteca.GenerarCodigo(), ejemplar);
            biblioteca.Agregar(libro);
        }

        private void RegistrarDigital()
        {
            string titulo = EntradaHelper.LeerTexto("Título: ");
            string autor = EntradaHelper.LeerTexto("Autor: ");
            double tam = EntradaHelper.LeerDouble("Tamaño MB: ");

            var libro = new LibroDigital(titulo, autor, biblioteca.GenerarCodigo(), tam);
            biblioteca.Agregar(libro);
        }

        private void BuscarTitulo()
        {
            string titulo = EntradaHelper.LeerTexto("Buscar: ");
            var lista = biblioteca.BuscarTitulo(titulo);

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
            m?.Prestar();
        }

        private void Devolver()
        {
            string codigo = EntradaHelper.LeerTexto("Código: ");
            var m = biblioteca.BuscarCodigo(codigo);
            m?.Devolver();
        }
    }
}
