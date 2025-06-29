using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("=== Esperto Contra Sabido (Vila do Chaves) ===\n");

        int totalSanduiches;

        while (true)
        {
            Console.Write("Quantos sanduíches de presunto serão distribuídos? ");
            if (int.TryParse(Console.ReadLine(), out totalSanduiches) && totalSanduiches > 0)
                break;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ei! Isso não é um número válido. Tenta de novo, vai!");
            Console.ResetColor();
        }

        int sabido = 0;
        int esperto = 0;
        int rodada = 1;
        int sanduichesRestantes = totalSanduiches;

        Console.WriteLine();

        while (sanduichesRestantes > 0)
        {
            // Turno do Sabido
            int paraSabido = Math.Min(rodada, sanduichesRestantes);
            Console.WriteLine($"[Rodada {rodada}] Sabido: \"Oba! {paraSabido} pra mim!\"");
            sabido += paraSabido;
            sanduichesRestantes -= paraSabido;

            // Turno do Esperto
            if (sanduichesRestantes > 0)
            {
                int paraEsperto = Math.Min(rodada, sanduichesRestantes);
                Console.Write("[Esperto]: \"Eu recebo ");
                for (int i = 1; i <= paraEsperto; i++)
                {
                    if (i > 1) Console.Write(", ");
                    Console.Write(i);
                }
                Console.WriteLine(" sanduíches!\"");
                esperto += paraEsperto;
                sanduichesRestantes -= paraEsperto;
            }

            rodada++;
            Console.WriteLine();
        }

        Console.WriteLine("=== Resultado Final ===\n");
        Console.WriteLine($"Sabido comeu {sabido} sanduíche(s) de presunto.");
        Console.WriteLine($"Esperto comeu {esperto} sanduíche(s) de presunto.");

        if (esperto > sabido)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nEsperto: \"Viu só, Sabido? Eu sou mesmo mais esperto! Ñanha ñanha!\"");
            Console.ResetColor();
        }
        else if (sabido > esperto)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSabido: \"Isso, isso, isso! Ganhei mais sanduíches!\"");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("\nNarrador: \"Parece que foi um empate entre o Esperto e o Sabido.\"");
        }
    }
}
