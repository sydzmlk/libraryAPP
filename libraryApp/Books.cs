using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace libraryApp
{
    internal class Books
    {
        public string title { get; set; }
        public string genre { get; set; }
        public string author { get; set; }

        List<Books> kitablar = new List<Books>();
        public void addBooks()
        {
            var kitab1 = new Books()
            {
                title = "Melekler ve Seytanlar",
                genre = "Macera",
                author = "Dan Brown",
            };
            kitablar.Add(kitab1);

            var kitab2 = new Books()
            {
                title = "Qan Qirmizisi Caylar",
                genre = "Dedektif",
                author = "Jean- Christophe Range",
            };
            kitablar.Add(kitab2);

            var kitab3 = new Books()
            {
                title = "Insanin anlam axtarisi",
                genre = "Psixoloji",
                author = "Viktor Frankl",
            };
            kitablar.Add(kitab3);

            var kitab4 = new Books()
            {
                title = "Martin Eden",
                genre = "Sevgi",
                author = "Jack London",
            };
            kitablar.Add(kitab4);
        }
        public void ShowBooks()
        {
            foreach (var kitap in kitablar)
            {
                Console.WriteLine($"{kitap.title} - {kitap.author} - {kitap.genre}");
                Console.WriteLine("******************************************************");
            }

        }

        public void searchBooks(string keywords)
        {
            if (string.IsNullOrEmpty(keywords))
            {
                Console.WriteLine("Duzgun axtaris sozu daxil edilmeyib!");
                return;
            }
            var result = kitablar.Where(k => k.title.Contains(keywords, StringComparison.OrdinalIgnoreCase) ||
            k.genre.Contains(keywords, StringComparison.OrdinalIgnoreCase) || k.author.Contains(keywords, StringComparison.OrdinalIgnoreCase)).ToList();
            if (result.Count == 0)
            {
                Console.WriteLine("Axtarisiniza uygun netice teesuf ki tapilmadi");
            }
            else
            {
                Console.WriteLine("Axtarisinizin Neticesi:");
                foreach (var kitab in result)
                {
                    Console.WriteLine($"{kitab.title} - {kitab.author} - {kitab.genre}");
                    Console.WriteLine("***************************************************");
                }
            }
        }

        public void editBooks()
        {
            Console.WriteLine("Zehmet olmasa redakte edeceyiniz kitabin adini qeyd edin");
            string input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("Ad hissesi bos buraxila bilmez");
                return;
            }
            var bookname = kitablar.FirstOrDefault(k => k.title.Equals(input, StringComparison.OrdinalIgnoreCase));
            if (bookname == null)
            {
                Console.WriteLine("Bu adda kitab tapilmadi!");
                return;
            }

            Console.WriteLine("Kitabin yeni adini daxil edin");
            string newTitle = Console.ReadLine();
            if (!string.IsNullOrEmpty(newTitle)) {
                bookname.title = newTitle;
            }
            else
            {
                Console.WriteLine("Duzgun ad daxil edin,format xetasi!");
                return;
            }
            Console.WriteLine("Yazicinin yeni adini daxil edin");
            string newAuthor = Console.ReadLine();
            if (!string.IsNullOrEmpty(newAuthor))
            {
                bookname.author = newAuthor;
            }
            else
            {
                Console.WriteLine("Duzgun ad daxil edin,format xetasi!");
                return;
            }
            Console.WriteLine("Kitabin yeni janr novunu daxil edin");
            string newGenre = Console.ReadLine();
            if (!string.IsNullOrEmpty(newGenre))
            {
                bookname.genre = newGenre;
            }
            else
            {
                Console.WriteLine("Duzgun ad daxil edin,format xetasi!");
                return;
            }
            Console.WriteLine("Proses ugurla tamamlanmisdir!");
            Console.WriteLine("Redakte edilen kitab :");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine($"{bookname.title} - {bookname.author} - {bookname.genre}");
            Console.WriteLine("---------------------------------------------------------");


        }


        public void AddNewBook()
        {
            Console.WriteLine("Zehmet olmasa elave edeceyiniz kitabin adini daxil edin:");
            var newBookTitle = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newBookTitle))
            {
                Console.WriteLine("Ad hissesi boş buraxila bilmez!");
                return;
            }
            var existingBook = kitablar.FirstOrDefault(k => k.title.Equals(newBookTitle, StringComparison.OrdinalIgnoreCase));

            if (existingBook != null)
            {
                Console.WriteLine("Bu adda kitab artig movcuddur.");
                return;
            }
            Console.WriteLine("Yazicinin adini daxil edin:");
            var newAuthor = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newAuthor))
            {
                Console.WriteLine("Yaziçi hissesi boş buraxila bilmez!");
                return;
            }

            Console.WriteLine("Janr daxil edin:");
            var newGenre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newGenre))
            {
                Console.WriteLine("Janr hissesi boş buraxila bilmez!");
                return;
            }
            Books yeniKitab = new Books
            {
                title = newBookTitle,
                author = newAuthor,
                genre = newGenre
            };

            kitablar.Add(yeniKitab);
            Console.WriteLine("Kitab ugurla elave olundu!");
        }
    }
}

