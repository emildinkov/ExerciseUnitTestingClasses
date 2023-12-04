using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class ArticleTests
{
    private Article _article;

    [SetUp]
    public void SetUp()
    {
        this._article = new Article();
    }

    [Test]
    public void Test_AddArticles_ReturnsArticleWithCorrectData()
    {
        // Arrange
        string[] articleData =
        {
            "Article Content Author",
            "Article Content2 Author",
            "Artical Content Author3",
        };

        // Act
        Article result = this._article.AddArticles(articleData);

        // Assert
        Assert.That(result.ArticleList, Has.Count.EqualTo(3));
        Assert.That(result.ArticleList[0].Title, Is.EqualTo("Article"));
        Assert.That(result.ArticleList[1].Content, Is.EqualTo("Content2"));
        Assert.That(result.ArticleList[2].Author, Is.EqualTo("Author3"));
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByTitle()
    {
        // Arrange
        Article input = new Article()
        {
            ArticleList = new()
            {
                new Article()
                {
                    Author = "Emil",
                    Content = "Some content",
                    Title = "Title"
                },
                new Article()
                {
                    Author = "Emil's",
                    Content = "Some content",
                    Title = "Above"
                }
            }
        };

        string printCriteria = "title";

        string expected = $"Above - Some content: Emil's{Environment.NewLine}Title - Some content: Emil";

        // Act
        string actual = this._article.GetArticleList(input, printCriteria);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetArticleList_ReturnsEmptyString_WhenInvalidPrintCriteria()
    {
        // Arrange
        Article input = new Article()
        {
            ArticleList = new()
            {
                new Article()
                {
                    Author = "Emil",
                    Content = "Some content",
                    Title = "Title"
                },
                new Article()
                {
                    Author = "Emil's",
                    Content = "Some content",
                    Title = "Above"
                }
            }
        };

        string printCriteria = "futbol";

        // Act
        string actual = this._article.GetArticleList(input, printCriteria);

        // Assert
        Assert.That(actual, Is.Empty);
    }
}
