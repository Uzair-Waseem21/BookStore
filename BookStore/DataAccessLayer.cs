using BookStore;
namespace DAL;
internal class BookDataAccess
{
    List<Book> books = new List<Book>();

  public void AddBook()
  {
    Console.WriteLine("Enter Book Id: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Book Title: ");
    string title = Console.ReadLine();
    Console.WriteLine("Enter Book Author: ");
    string author = Console.ReadLine();
    Console.WriteLine("Enter Book Price: ");
    double price = Convert.ToDouble(Console.ReadLine());
    Book book = new Book(id, title, author, price);
    FileStream fs = new FileStream("books.txt", FileMode.Append);
    StreamWriter sw = new StreamWriter(fs);
    sw.WriteLine($"{book.Id},{book.Title},{book.Author},{book.Price}");
    sw.Close();
    fs.Close();
  }
  public void ViewAllBooks()
  {
    books.Clear();
    FileStream fs = new FileStream("books.txt", FileMode.Open);
    StreamReader sr = new StreamReader(fs);
    string? line=sr.ReadLine();
    if(line == null)
    {
      Console.WriteLine("No books found.");
      sr.Close();
      fs.Close();
      return;
    }
    while (line != null)
    {
      String[] parts = line.Split(',');
      int id = Convert.ToInt32(parts[0]);
      string title = parts[1];
      string author = parts[2];
      double price = Convert.ToDouble(parts[3]);
      books.Add(new Book(id, title, author, price));
      line = sr.ReadLine();
    }
    foreach (Book book in books)
    {
      book.DisplayInfo();
    }
      sr.Close();
      fs.Close();
  }
  public void FindBookById()
  {
    Console.WriteLine("Enter Book Id to search: ");
    int searchId = Convert.ToInt32(Console.ReadLine());
    FileStream fs = new FileStream("books.txt", FileMode.Open);
    StreamReader sr = new StreamReader(fs);
    string? line = sr.ReadLine();
    if(line == null)
    {
      Console.WriteLine("No books found.");
      sr.Close();
      fs.Close();
      return;
    }
    while (line != null)
    {
      string[] parts = line.Split(',');
      int id = Convert.ToInt32(parts[0]);
      if (id == searchId)
      {
        string title = parts[1];
        string author = parts[2];
        double price = Convert.ToDouble(parts[3]);
        Book book = new Book(id, title, author, price);
        book.DisplayInfo();
        sr.Close();
        fs.Close();
        return;
      }
      line = sr.ReadLine();
    }
    Console.WriteLine("Book not found.");
    sr.Close();
    fs.Close();
  }
    public void CreateBackup()
    {
    FileStream fr = new FileStream("books.txt", FileMode.Open);
    FileStream fw = new FileStream("books_backup.txt", FileMode.Create);

    int x = fr.ReadByte();

    if (x == -1)
    {
        Console.WriteLine("No books found to backup.");
        fr.Close();
        fw.Close();
        return;
    }

    while (x != -1)
    {
        fw.WriteByte((byte)x);
        x = fr.ReadByte();
    }

    Console.WriteLine("Backup created successfully.");

    fr.Close();
    fw.Close();
}
}