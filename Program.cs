static string inverte(string s)
{
    Pilha v = new Pilha(s.Length);

    foreach (char c in s)
    {
        v.empilha(c);
    }

    string invertida = "";

    while (!v.vazia())
    {
        char b = (char)v.desempilha();
        invertida += b;
    }

    return invertida;
}

static bool balanceado(string expr)
{
    Pilha e = new Pilha(expr.Length);

    foreach (char c in expr)
    {
        if (c == '(' || c == '{' || c == '[')
        {
            e.empilha(c);
        }
        else if (c == ')' || c == '}' || c == ']')
        {
            if (e.vazia())
            {
                return false;
            }

            char topo = (char)e.consultaTopo();

            if (c == ')' && topo != '(')
            {
                return false;
            }

            if (c == ']' && topo != '[')
            {
                return false;
            }

            if (c == '}' && topo != '{')
            {
                return false;
            }

            e.desempilha();
        }
    }

    if (!e.vazia())
    {
        return false;
    }

    return true;
}

static int[] bubblePilhas(int[] v, out int comparacoes)
{
    comparacoes = 0;
    int n = v.Length;

    Pilha A = new Pilha(v.Length);
    Pilha B = new Pilha(v.Length);
    Pilha R = new Pilha(v.Length);

    for (int i = 0; i < n; i++)
    {
        A.empilha(v[i]);
    }

    for (int k = n; k > 0; k--)
    {
        int carry = A.desempilha();

        for (int j = 0; j < k - 1; j++)
        {
            int x = A.desempilha();

            comparacoes++;

            if (carry > x)
            {
                B.empilha(x);
            }
            else
            {
                B.empilha(carry);
                carry = x;
            }
        }

        R.empilha(carry);

        Pilha aux = A;
        A = B;
        B = aux;
    }

    int[] resultado = new int[v.Length];

    for (int i = 0; i < n; i++)
    {
        resultado[i] = R.desempilha();
    }

    return resultado;
}

static Pilha ordenaPilha(Pilha p)
{
    Pilha auxiliar = new Pilha(p.tamanho());

    while (!p.vazia())
    {
        int t = p.desempilha();

        while (!auxiliar.vazia() && auxiliar.consultaTopo() > t)
        {
            p.empilha(auxiliar.desempilha());
        }

        auxiliar.empilha(t);
    }

    return auxiliar;
}

int[] v = { 5, 2, 9, 1, 7 };
int comparacoes;

int[] resultado = bubblePilhas(v, out comparacoes);

Console.WriteLine(comparacoes);

for (int i = 0; i < resultado.Length; i++)
{
    Console.Write(resultado[i]);

    if (i != resultado.Length - 1)
    {
        Console.Write(",");
    }
}

Console.WriteLine();

int[] vOrdenado = { 1, 4, 7, 9 };
int comparacoesOrdenado;

int[] resultadoOrdenado = bubblePilhas(vOrdenado, out comparacoesOrdenado);

Console.WriteLine(comparacoesOrdenado);

for (int i = 0; i < resultadoOrdenado.Length; i++)
{
    Console.Write(resultadoOrdenado[i]);

    if (i != resultadoOrdenado.Length - 1)
    {
        Console.Write(",");
    }
}

Console.WriteLine();


Pilha p = new Pilha(5);

p.empilha(1);
p.empilha(3);
p.empilha(5);
p.empilha(7);

p.mostra();

Console.WriteLine(p.desempilha());
Console.WriteLine(p.consultaTopo());

p.empilha(8);
p.empilha(9);

p.mostra();

Console.WriteLine(p.cheia());

try
{
    p.empilha(2);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

string s = "PUCMINAS";
string invertida = inverte(s);

Console.WriteLine(invertida);

string texto1 = "(a+b)*[c-d]";
string texto2 = "{[()]}";
string texto3 = "((a)";
string texto4 = "a+b)";
string texto5 = "([)]";

Console.WriteLine(balanceado(texto1));
Console.WriteLine(balanceado(texto2));
Console.WriteLine(balanceado(texto3));
Console.WriteLine(balanceado(texto4));
Console.WriteLine(balanceado(texto5));

Pilha pilhaDesordenada = new Pilha(5);

pilhaDesordenada.empilha(5);
pilhaDesordenada.empilha(2);
pilhaDesordenada.empilha(9);
pilhaDesordenada.empilha(1);
pilhaDesordenada.empilha(7);

Pilha pilhaOrdenada = ordenaPilha(pilhaDesordenada);

pilhaOrdenada.mostra();