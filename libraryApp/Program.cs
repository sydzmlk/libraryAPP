using libraryApp;
using System.Security.Cryptography.X509Certificates;
int wrongchoice = 0;
Books books = new Books();
books.addBooks();
while (true)
{
    try
    {
        Menyu menyu = new Menyu();
        menyu.menyu();
     int secim = Convert.ToInt32(Console.ReadLine());
        if(secim >5 || secim < 0)
        {
            Console.WriteLine("Secim yalnizca 1 ile 5 arasinda ola biler!");
            Console.WriteLine("");
        }
        else
        {
            switch (secim)
            {
                case 5:
                    Console.WriteLine("Cixisiniz temin edilir...");
                    return;
                    case 1:
                    books.ShowBooks();
                    string getanswer = yesOrNo();
                    if (getanswer == "1") continue;
                    Console.WriteLine("Cixisiniz icradadir..");
                    return;
                case 2:
                    Console.WriteLine("Zehmet olmasa kitabin,muellifin ve ya eserin adini yazin");
                    var keywords = Console.ReadLine();
                    books.searchBooks(keywords);
                    var result = yesOrNo();
                    if (result == "1") continue;
                    Console.WriteLine("Cixisiniz icradadir..");
                    return;
                case 3:
                    books.editBooks();
                    string getanswer2 = yesOrNo();
                    if (getanswer2 == "1") continue;
                    Console.WriteLine("Cixisiniz icradadir..");
                    return;
                case 4:
                   books.AddNewBook();
                    string getanswer3 = yesOrNo();
                    if (getanswer3 == "1") continue;
                    Console.WriteLine("Cixisiniz icradadir..");
                    return;



            }

        }

    }
    catch
    {
        wrongchoice++;
        Console.WriteLine("Brat bosluq veya herf daxil etme!");
        Console.WriteLine("Xeta sayin : " + (wrongchoice));
        Console.WriteLine("");
        if(wrongchoice >= 2)
        {
            Console.WriteLine("Brat sansin bitdi,sonra goruserik!");
            break;
        }
        else
        {
            Console.WriteLine("Sene son bir sans verirem!");
            Console.WriteLine("");
            continue; 
        }
    }


}

 string yesOrNo()
{
    Console.WriteLine("Prosese davam etmek isteyirsiniz mi?");
    Console.WriteLine("1-Beli");
    Console.WriteLine("2-Xeyr");
    var answer = Console.ReadLine();
    return answer;

}