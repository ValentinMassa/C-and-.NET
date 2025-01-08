using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace _1
{
    public class LinqQuerys
    {
        private List<Book> _booksCollection = new();
        public LinqQuerys()
        {
                using(StreamReader reader = new StreamReader("books.json"))
                {
                    string json = reader.ReadToEnd();
                _booksCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    
                }
        }

        public IEnumerable<Book> AllBooks()
        {
            return _booksCollection;
        }

        internal object Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> bookUppery2000()
        {
            //extension method
            //return _booksCollection.Where(p=> p.publishedDate.Year > 2000);

            //query expression

            return from finalbooks in _booksCollection 
                where finalbooks.publishedDate.Year > 2000 select finalbooks;  
        }

        public IEnumerable<Book> bookUpper250PagesAndWordInAction()
        {
            //extension method
            //return _booksCollection.Where(p=> p.Title.Contains("in Action") && p.PageCount > 250);
            //query expression

            return from finalResult in _booksCollection
                where finalResult.Title.Contains("in Action") && finalResult.PageCount > 250
                    select finalResult;
        }

        public bool AllBooksHaveStatus()
        {
            return _booksCollection.All(p => p.status != string.Empty);
        }

        public bool IsAnyBookFrom2005()
        {
            return _booksCollection.Any(p=> p.publishedDate.Year == 2005);
        }

        public IEnumerable<Book> BookInPython()
        {
            return _booksCollection.Where(p=> p.categories.Contains("Python"));
        }

        public IEnumerable<Book> BookAscJava()
        {
            return _booksCollection.Where(p=> p.categories.Contains("Java")).OrderBy(p=> p.Title);
        }

        public IEnumerable<Book> BooksUpper450PagesOrderDescByPage()
        {
            return _booksCollection.Where(p=> p.PageCount > 450).OrderByDescending(p=> p.PageCount);
        }

        public IEnumerable<Book> First3JavaBookMoreRecently()
        {
            return BookAscJava().OrderBy(p=> p.publishedDate).Take(3);
        }

        public IEnumerable<Book> WithSkipThirdAndFourthbookWithPagesUpper400()
        {
            return _booksCollection.Where(p=> p.PageCount >400).Skip(2).Take(2);
        }

        public IEnumerable<Book> First3Books()
        {
            return _booksCollection.Take(3)
                .Select(p=> new Book() {Title = p.Title, PageCount = p.PageCount});
        }

        public int CountBooksBetweenlimInfXandlimSupY(int x, int y)
        {
            return _booksCollection.Count(p=> p.PageCount >= x && p.PageCount <= y);
        }

        public DateTime MinorPublisedDate()
        {
            return _booksCollection.Min(p=> p.publishedDate);
        } 

        public int MaxAmountOfPages()
        {
            return _booksCollection.Max(p=> p.PageCount);
        }

        public Book BookWithMinorPagesButGratherThan0()
        {
            return _booksCollection.Where(p=> p.PageCount > 0).MinBy(p=> p.PageCount);
        }
        public Book BookWithMostRecentlyPublisheDate()
        {
            return _booksCollection.MinBy(p=> p.publishedDate);
        }

        public int SumOfPagesOfBooksWithPagesBetweenXandY(int x, int y)
        {
            return _booksCollection.Where(p => p.PageCount > x && p.PageCount <= y).Sum(p => p.PageCount);
        }

        public string TitleOfBooksWIthYearGratherThanX(int x)
        {
            return _booksCollection.Where(p=> p.publishedDate.Year > x)
                .Aggregate("", (stringOfTitles, next) =>{
                    if(stringOfTitles != string.Empty)
                        stringOfTitles += $" - {next.Title}";
                    else    
                        stringOfTitles += $"{next.Title}";
                    
                    return stringOfTitles;
                });
        }


        public double AverageOfCharactersPerTitle()
        {
            return _booksCollection.Average(p=> p.Title.Length);
        }

        public IEnumerable<IGrouping<int, Book>> BooksPublisedDateUperOrEqualToXYearGroupByYear(int x)
        {
            return _booksCollection.Where(p=> p.publishedDate.Year >= x)
                .GroupBy(p=> p.publishedDate.Year);
        }

        public ILookup<char, Book>  DictionaryOfBooksByFirstLetter()
        {
            return _booksCollection.ToLookup(p=> p.Title[0], p=>p);
        }
        public IEnumerable<dynamic> BookWithMoreThanXPagesCountAndNewerThanYearY(int x, int y)
        {
            var booksWithMoreThanXPagesCount = _booksCollection.Where(p=> p.PageCount > x);
            var booksNewerthanY = _booksCollection.Where(p=> p.publishedDate.Year > y);
            
            return booksWithMoreThanXPagesCount.Join(
                booksNewerthanY, p=>p.Title, x=>x.Title, (p,x)=> 
                    new {Authors = AuthorInStringFormat(p.Authors), p.PageCount}
                );
        }

        public IEnumerable<dynamic> AuthorsOfBooksWithPageNumber()
        {
            return _booksCollection.Select(p=> new{Authors= AuthorInStringFormat(p.Authors), p.PageCount});
        }


        private string AuthorInStringFormat(string[] authors)
        {
            return authors.Aggregate("", (stringA, next) =>
            {
                if(stringA != string.Empty)
                    stringA += $" - {next}";
                else
                    stringA += $"{next}";

            return stringA;
           });
        }

    }

} 