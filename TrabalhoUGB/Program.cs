using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear(); // Limpa o console a cada exibição do menu
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Verificar se o número é palíndromo");
            Console.WriteLine("2. Adivinhar o número (usando recursão)");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    VerificarPalindromo();
                    break;

                case "2":
                    AdivinharNumero(); // Função de adivinhar o número
                    break;

                case "3":
                    running = false;
                    Console.WriteLine("Saindo...");
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey(); // Pausa para o usuário ler a mensagem de erro
                    break;
            }
        }
    }

    // Função para verificar se um número é palíndromo
    static void VerificarPalindromo()
    {
        Console.Write("Digite um número: ");
        string numero = Console.ReadLine();

        if (EhPalindromo(numero))
        {
            Console.WriteLine($"O número {numero} é um palíndromo.");
        }
        else
        {
            Console.WriteLine($"O número {numero} não é um palíndromo.");
        }

        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }

    // Função para verificar se a string de um número é palíndromo
    static bool EhPalindromo(string numero)
    {
        int inicio = 0;
        int fim = numero.Length - 1;

        while (inicio < fim)
        {
            if (numero[inicio] != numero[fim])
            {
                return false;
            }
            inicio++;
            fim--;
        }

        return true;
    }

    // Função para adivinhar o número
    static void AdivinharNumero()
    {
        Random random = new Random();
        int numeroAleatorio = random.Next(1, 101); // Número aleatório entre 1 e 100
        Console.WriteLine("Tente adivinhar o número entre 1 e 100!");

        // Chamada inicial da função recursiva
        TentarAdivinhar(numeroAleatorio);
    }

    // Função recursiva que tenta adivinhar o número
    static void TentarAdivinhar(int numeroCorreto)
    {
        Console.Write("Digite seu palpite: ");
        int palpite;

        // Verifica se a entrada é um número válido
        if (int.TryParse(Console.ReadLine(), out palpite))
        {
            if (palpite < numeroCorreto)
            {
                Console.WriteLine("O número correto é maior. Tente novamente.");
                TentarAdivinhar(numeroCorreto); // Recursão: chama a função novamente
            }
            else if (palpite > numeroCorreto)
            {
                Console.WriteLine("O número correto é menor. Tente novamente.");
                TentarAdivinhar(numeroCorreto); // Recursão: chama a função novamente
            }
            else
            {
                Console.WriteLine("Parabéns! Você adivinhou o número!");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey(); // Pausa para o usuário voltar ao menu
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida. Por favor, insira um número.");
            TentarAdivinhar(numeroCorreto); // Chama a função novamente se a entrada for inválida
        }
    }
}
