namespace IPC2S1.Utilidades
{
    public static class EntradaHelper
    {
        public static int LeerEntero(string msg)
        {
            int valor;
            while (true)
            {
                Console.Write(msg);
                if (int.TryParse(Console.ReadLine(), out valor))
                    return valor;

                Console.WriteLine("Entrada inválida.");
            }
        }

        public static double LeerDouble(string msg)
        {
            double valor;
            while (true)
            {
                Console.Write(msg);
                if (double.TryParse(Console.ReadLine(), out valor))
                    return valor;

                Console.WriteLine("Entrada inválida.");
            }
        }

        public static string LeerTexto(string msg)
        {
            string texto;
            do
            {
                Console.Write(msg);
                texto = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(texto));

            return texto;
        }
    }
}
