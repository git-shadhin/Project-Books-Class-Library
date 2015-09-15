using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Mime;

namespace SCL
{
    public class Book
    {
        private static byte[] GetPhoto(string filePath)
        {
            if (File.Exists(filePath))
            {
                FileStream stream = new FileStream(
                    filePath, FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(stream);

                byte[] photo = reader.ReadBytes((int)stream.Length);

                reader.Close();
                stream.Close();

                return photo;
            }
            else return null;
            
        }
        private static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string PhotoPath { get; set; }
        public string Category { get; set; }
        public decimal Mark { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public byte[] Photo { get; set; }
        public string StringB64 
            { 
                get 
                {
                    if (this.Photo != null)
                    {
                        return "data:image/png;base64," + Convert.ToBase64String(this.Photo); 
                    }
                    else
                    {
                        return "data:image/png;base64," + StaticResources.defaultPhoto;
                    }
                }
                set { }
                
            }
        
        public string Description { get; set; }

        /// <summary>
        /// Initialise a Book object
        /// </summary>
        /// 
        /// <param name="title">The book's title</param>
        /// <param name="author">The author's name</param>
        /// <param name="photoPath">A valid path to a photo</param>
        public Book(string title, string author, string category, string photoPath)
        {
            if (title != "")
                this.Title = UppercaseFirst(title);
            else
                throw new EmptyBookTitleException();

            if (author != "")
                this.Author = author;
            else
                throw new EmptyAuthorNameException();

            if (photoPath != "")
            {
                    this.PhotoPath = photoPath;
                    Photo = GetPhoto(photoPath);
                
            }
            else
                throw new EmptyPhotoPathException();

            if (category != "")
            {
                this.Category = category;
            }
            else
                throw new EmptyCategory();
        }

        public Book(bool t, string title, string author, string category, string photoPath, decimal price, string description)
        {
            if (title != "")
                this.Title = UppercaseFirst(title);
            else
                throw new EmptyBookTitleException();
            if (category != "")
            {
                this.Category = category;
            }
            else
                throw new EmptyCategory();

            if (author != "")
            {
                this.Author = author;
            }
            else this.Author = "Unknown Author";

            //////////////////////////
            if (photoPath!="" && File.Exists(photoPath))
            {
                this.PhotoPath = photoPath;
                this.Photo = GetPhoto(photoPath);

            }
            else
            {
                this.PhotoPath = "";
                this.Photo = null;
            }

            if (price>0)
            {
                this.Price = price;
            }
            else
            {
                this.Price = 0;
            }

            if (!String.IsNullOrEmpty(description))
            {
                this.Description = description;
            }
            else
            {
                this.Description = "There isn't a description for this book at the moment";
            }
        }

        public Book(string title, string author, string category)
        {
            if (title != "")
                this.Title = UppercaseFirst(title);
            else
                throw new EmptyBookTitleException();

            if (author != "")
                this.Author = UppercaseFirst(author);
            else
                throw new EmptyAuthorNameException();

            if (category != "")
            {
                this.Category = category;
            }
            else
                throw new EmptyCategory();

            this.PhotoPath = "";
        }

        public Book(string title, string category)
        {
            if (title != "")
                this.Title = UppercaseFirst(title);
            else
                throw new EmptyBookTitleException();
            if (category != "")
            {
                this.Category = category;
            }
            else
                throw new EmptyCategory();
            this.Author = "Unknown Author";
            this.PhotoPath = "";
            this.Photo = null;

        }

        public Book() {
           
        }

        public override string ToString()
        {
            return this.Title;
        }
        
    }
}
