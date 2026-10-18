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

string texto = "([)]";
bool ehBalanceado = balanceado(texto);

Console.WriteLine(ehBalanceado);