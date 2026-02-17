using System.Text;

namespace IPC2S1.Servicios

{
    public static class GeneradorCodigo
    {
        private static Random random = new Random();
        private const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string Generar(HashSet<string> existentes)
        {
            string codigo;

            do
            {
                StringBuilder nuevo = new StringBuilder();
                for (int i = 0; i < 8; i++)
                    nuevo.Append(caracteres[random.Next(caracteres.Length)]);

                codigo = nuevo.ToString();

            } while (existentes.Contains(codigo));

            return codigo;
        }
    }
}
