using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCL
{
    [Serializable]
    public class Review
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public string Text { get; set; }
        public decimal Mark { get; set; }

        public Review(int authorId, int bookId, string text, decimal mark)
        {
            this.AuthorId = authorId;
            this.BookId = bookId;
            if (!String.IsNullOrEmpty(text))
            {
                this.Text = text; 
            }
            else
            {
                this.Text = "Without comment";
            }
            if (mark < 0)
            {
                this.Mark = 0;
            }
            else if (mark>5)
            {
                this.Mark = 5;
            }
            else
            {
                this.Mark = mark;
            }
            
        }

        
        public Review(Book book, int authorId, string text, decimal mark)
        {
            this.BookId = book.Id;

            if (!String.IsNullOrEmpty(text))
            {
                this.Text = text;
            }
            else
            {
                this.Text = "Without comment";
            }
            if (mark.CompareTo(-1).Equals(0))
            {
                this.Mark = 0;
            }
            if (mark > 5)
            {
                this.Mark = 5;
            }
            else { this.Mark = mark; }
        }

        public Review() { }
        public override string ToString()
        {
            return String.Format("Review author id: {0}; Reviewed Book id: {1}; \nReview Text: {2}; \nReview Mark: {3}", 
                this.AuthorId, this.BookId, this.Text, this.Mark);
        }
    }
}
