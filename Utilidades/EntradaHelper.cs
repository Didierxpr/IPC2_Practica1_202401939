namespace IPC2S1.Utilidades
{
    public static class EntradaHelper
    {
        public static string LeerTexto(string msg)
        {
            string texto;
            do
            {
                Console.Write(msg);
                texto = Console.ReadLine() ?? "";
                texto = texto.Trim();
                if (string.IsNullOrWhiteSpace(texto))
                    Console.WriteLine("No puede quedar vacío. Intente de nuevo.");
            } while (string.IsNullOrWhiteSpace(texto));

            return texto;
        }

        public static int LeerEntero(string msg, int? min = null, int? max = null)
        {
            while (true)
            {
                Console.Write(msg);
                string entrada = (Console.ReadLine() ?? "").Trim();

                if (!int.TryParse(entrada, out int valor))
                {
                    Console.WriteLine("Entrada inválida. Debe ser un número entero.");
                    continue;
                }

                if (min.HasValue && valor < min.Value)
                {
                    Console.WriteLine($"El valor debe ser >= {min.Value}.");
                    continue;
                }

                if (max.HasValue && valor > max.Value)
                {
                    Console.WriteLine($"El valor debe ser <= {max.Value}.");
                    continue;
                }

                return valor;
            }
        }

        public static double LeerDouble(string msg, double? min = null, double? max = null)
        {
            while (true)
            {
                Console.Write(msg);
                string entrada = (Console.ReadLine() ?? "").Trim();

                if (!double.TryParse(entrada, out double valor))
                {
                    Console.WriteLine("Entrada inválida. Debe ser un número.");
                    continue;
                }

                if (min.HasValue && valor < min.Value)
                {
                    Console.WriteLine($"El valor debe ser >= {min.Value}.");
                    continue;
                }

                if (max.HasValue && valor > max.Value)
                {
                    Console.WriteLine($"El valor debe ser <= {max.Value}.");
                    continue;
                }

                return valor;
            }
        }
    }
}