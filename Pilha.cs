public class Pilha
{
    private int[] item;
    private int topo;

    public Pilha(int maxTam)
    {
        this.item = new int[maxTam];
        this.topo = 0;
    }

    public bool vazia()
    {
        if (this.topo == 0)
        {
            return true;
        }

        return false;
    }

    public bool cheia()
    {
        if (this.topo == item.Length)
        {
            return true;
        }

        return false;
    }

    public int tamanho()
    {
        return this.topo;
    }

    public void empilha(int x)
    {
        if (topo < item.Length)
        {
            item[topo] = x;
            topo++;
        }
        else
        {
            throw new Exception("Erro: pilha cheia");
        }
    }

    public int desempilha()
    {
        if (topo == 0)
        {
            throw new Exception("Erro: pilha vazia");
        }

        topo--;

        return item[topo];
    }

    public int consultaTopo()
    {
        if (topo == 0)
        {
            throw new Exception("Erro: pilha vazia");
        }

        return item[topo - 1];
    }

    public void mostra()
    {
        Console.Write("[");

        for (int i = 0; i < topo; i++)
        {
            Console.Write($"{item[i]}");

            if (i != topo - 1)
            {
                Console.Write(", ");
            }
        }

        Console.Write("]");
        Console.WriteLine();
    }
}