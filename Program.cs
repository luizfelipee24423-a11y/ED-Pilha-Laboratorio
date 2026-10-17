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