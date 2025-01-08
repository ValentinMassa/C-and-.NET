using System;
using System.Linq;

using _1;

var books = new LinqQuerys();

/*
PrintValues(books.AllBooks());
all collection
*/

/*
books upper collection
*/
//PrintValues(books.bookUppery2000());

//PrintValues(books.bookUpper250PagesAndWordInAction());

//all books have status

Console.WriteLine($" all books have  Status: {books.AllBooksHaveStatus()}");
Console.WriteLine("\n");
Console.WriteLine("---------------------------------------------");
Console.WriteLine("\n");

Console.WriteLine($" Any book from 2005?: {books.IsAnyBookFrom2005()}");
Console.WriteLine("\n");
Console.WriteLine("---------------------------------------------");
Console.WriteLine("\n");

// python books
Console.WriteLine("Pythom Books\n");
PrintValues(books.BookInPython());

//java books order by name
Console.WriteLine("Java books order by title\n");
PrintValues(books.BookAscJava());

//bookspage > 450 order by pagecunt
Console.WriteLine("books whith > 450 pages order by pageCount dessc\n");
PrintValues(books.BooksUpper450PagesOrderDescByPage());

//top 3 java books recently published
Console.WriteLine("top 3 java books recently published\n");
PrintValues(books.First3JavaBookMoreRecently());

//top 3 and 4 book with pages upper than 400 with SKIP operator
Console.WriteLine("top 3 and 4 book with pages upper than 400\n");
PrintValues(books.WithSkipThirdAndFourthbookWithPagesUpper400());

//Three first books filtred by select
Console.WriteLine("Three first books filtred by select\n");
PrintValues(books.First3Books());

//Books with pages between x and y
Console.WriteLine("Books with pages between 200 and 500\n");
Console.WriteLine("\n");
Console.WriteLine($"Amount of books with 200 adnb 500 pages: {books.CountBooksBetweenlimInfXandlimSupY(200, 500)}");
Console.WriteLine("---------------------------------------------");
Console.WriteLine("\n");


//Minor Publised Date
Console.WriteLine("Minor Publised Date\n");
Console.WriteLine("\n");
Console.WriteLine($"Minor Publised Date: {books.MinorPublisedDate().Year}");
Console.WriteLine("---------------------------------------------");
Console.WriteLine("\n");

//Max Amount of Pages
Console.WriteLine("Max Amount of Pages\n");
Console.WriteLine("\n");
Console.WriteLine($"Max Amount of Pages: {books.MaxAmountOfPages()}");
Console.WriteLine("---------------------------------------------");
Console.WriteLine("\n");

//Book With Minor Pages But Grather Than 0
var QueryBook =  books.BookWithMinorPagesButGratherThan0();
Console.WriteLine("Book With Minor Pages But Grather Than 0\n");
Console.WriteLine($"Title: {QueryBook.Title}, PageCount: {QueryBook.PageCount}");
Console.WriteLine("---------------------------------------------");
Console.WriteLine("\n");

//Book With Most Recently Publishe Date
QueryBook =  books.BookWithMostRecentlyPublisheDate();
Console.WriteLine("Book With Most Recently Publishe Date\n");
Console.WriteLine($"Title: {QueryBook.Title}, PageCount: {QueryBook.PageCount}");
Console.WriteLine("---------------------------------------------");
Console.WriteLine("\n");

//The sum of Pages of Books with pages between x and y
Console.WriteLine("The sum of Pages of Books with pages between 0 and 500\n");
Console.WriteLine("\n");
Console.WriteLine($"Sum of Pages: {books.SumOfPagesOfBooksWithPagesBetweenXandY(0,500)} \n");
Console.WriteLine("---------------------------------------------");
Console.WriteLine("\n");

//Titles of Books with Year Grather Than x
Console.WriteLine($"Titles of Books with Year Grather Than x: {books.TitleOfBooksWIthYearGratherThanX(2015)}\n");
Console.WriteLine("\n");

//Avarage of characters in all books.title 
Console.WriteLine("Avarage of characters in all books.title \n");
Console.WriteLine("\n");
Console.WriteLine($"Result: {books.AverageOfCharactersPerTitle()} \n");
Console.WriteLine("---------------------------------------------");
Console.WriteLine("\n");

//GROUP BY YEAR
PrintIgrouping(books.BooksPublisedDateUperOrEqualToXYearGroupByYear(2000));

//dictionary by letter

PrintDictionary(books.DictionaryOfBooksByFirstLetter(), 'S');


//Join clause
Console.WriteLine("Join Clause \n");
var JoinResult = books.BookWithMoreThanXPagesCountAndNewerThanYearY(600, 1990);
PrintJoin(JoinResult);



//----------------------------------PRINTS---------------------------------------//


void PrintValues(IEnumerable<Book> bookList)
{
    Console.WriteLine("{0, -60} {1, 9} {2,11}\n","TITULO" ,"NRO PAGINAS","FECHA PUBLICACION");
    bookList.ToList().ForEach(p => Console.WriteLine("{0, -60} {1, 9} {2,11}", 
                                    p.Title, p.PageCount, p.publishedDate.ToShortDateString()));
    Console.WriteLine("\n");
    Console.WriteLine("---------------------------------------------");
    Console.WriteLine("\n");
}

void PrintJoin(IEnumerable<dynamic> bookList)
{
    Console.WriteLine("{0, -70} {1, 9}\n","AUTORES" ,"NRO PAGINAS");
    bookList.ToList().ForEach(p => Console.WriteLine("{0, -70} {1, 9} \n",  
                                   p.Authors, p.PageCount));
    Console.WriteLine("---------------------------------------------");
}

void PrintIgrouping(IEnumerable<IGrouping<int, Book>> bookList)
{
    foreach(var group in bookList)
    {
        Console.WriteLine("\n");
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine($"AÑO PUBLICACION: {group.Key}");
        Console.WriteLine("---------------------------------------------\n");

        Console.WriteLine("{0,-10} {1, -60} {2, -10} \n", "FECHA", "TITULO" , "NRO PAGINAS");
        foreach(var item in group)
        {
            Console.WriteLine("{0,-10} {1, -60} {2, -10}", 
                item.publishedDate.ToShortDateString(), item.Title?.ToUpper(), item.PageCount);
        }
    }
    Console.WriteLine("\n");
}

void PrintDictionary(ILookup<char, Book> BookList, char letter)
{
    Console.WriteLine("---------------------------------------------");
    Console.WriteLine($"RESULTADOS POR LETRA: {letter}");
    Console.WriteLine("---------------------------------------------\n");
    Console.WriteLine("{0,-10} {1, -60} {2, -10} \n", "FECHA", "TITULO" , "NRO PAGINAS");
    foreach (var item in BookList[letter])
    {
        Console.WriteLine("{0,-10} {1, -60} {2, -10}", 
                item.publishedDate.ToShortDateString(), item.Title?.ToUpper(), item.PageCount);
    }
}